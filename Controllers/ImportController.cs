using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_Warehouse.Common;
using Smart_Warehouse.Data;
using Smart_Warehouse.Models.Entities.Inventories;
using Smart_Warehouse.Models.Entities.Order;
using Smart_Warehouse.Models.Requests;
using Smart_Warehouse.Models.Requests.Import;
using Smart_Warehouse.Models.Respones.Import;
using System.Runtime.InteropServices;
using static Smart_Warehouse.Common.Enums;

namespace Smart_Warehouse.Controllers
{
    [ApiController]
    [Route("api/imports")]
    public class ImportController : ControllerBase
    {
        readonly DatabaseContext _context;
        readonly IMapper _mapper;

        public ImportController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ImportResponse>>> GetAllImports([FromQuery]FillterRequest fillter)
        {
            var query = _context.Imports
                .ProjectTo<ImportResponse>(_mapper.ConfigurationProvider)
                .AsQueryable();

            if (fillter.status.HasValue && fillter.status != Status.All)
            {
                query = query.Where(x => x.Status == fillter.status);
            }
            if (fillter.date.HasValue)
            {
                var fillterDate = fillter.date.Value;
                query = query.Where(x => x.CreatedAt == fillterDate);
            }
            if (!string.IsNullOrWhiteSpace(fillter.warehouse) && fillter.warehouse != "all")
            {
                query = query.Where(x => x.WarehouseName == fillter.warehouse);
            }

            var responses = await query.ToListAsync();

            return Ok(responses);
        }


        [HttpPost]
        public async Task<ActionResult> CreateImport([FromBody] CreateImportRequest request)
        {
            // Validate phiếu nhập
            if (request.Code == null || request.UserId == 0 || request.SupplierId == 0 || request.WarehouseId == 0 || request.ImportDetails.Count == 0)
                return BadRequest(Message.ImportInValid);

            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null || user.IsActive != true)
                return NotFound(Message.UserNotFound);

            var supplier = await _context.Suppliers.FindAsync(request.SupplierId);
            if (supplier == null || supplier.IsActive != true)
                return NotFound(Message.SupplierNotFound);

            var warehouse = await _context.Warehouses.FindAsync(request.WarehouseId);
            if (warehouse == null || warehouse.IsActive != true)
                return NotFound(Message.WarehouseNotFound);

            var currentStock = await _context.Inventories
               .Where(i => i.WarehouseId == request.WarehouseId)
               .SumAsync(i => i.Quantity);

            var importQuantity = 0;
            foreach (var detail in request.ImportDetails)
            {
                importQuantity += detail.Quantity;
            }
            if (currentStock + importQuantity > warehouse.MaxStock)
                    return BadRequest(Message.WarehouseOverMaxStock);

            // Tạo phiếu nhập
            var import = _mapper.Map<Import>(request);
            import.CreatedAt = DateTime.Now;
            import.IsActive = true;
            _context.Imports.Add(import);

            // Xử lý chi tiết phiếu nhập
            foreach (var detail in request.ImportDetails)
            {
                var product = await _context.Products.Where(p => p.Id == detail.ProductId).FirstOrDefaultAsync();
                if (product == null || product.IsActive != true)
                    return NotFound(Message.ProductNotFound);

                // Import detail
                var importDetailEntity = _mapper.Map<ImportDetail>(detail);
                importDetailEntity.Import = import;
                _context.ImportDetails.Add(importDetailEntity);
            }
            await _context.SaveChangesAsync();
            return Ok(Message.ImportCreated);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateImport(int id, [FromBody] UpdateImportRequest request)
        {
            var import = await _context.Imports.FindAsync(id);
            if (import == null)
                return NotFound(Message.ImportNotFound);
            _mapper.Map(request, import);
            import.UpdatedAt = DateTime.Now;

            if(request.Status == Status.Completed)
            {
                //Lấy danh sách sản phẩm của phiếu import này
                var importDetails = await _context.ImportDetails
                    .Where(d => d.ImportId == id)
                    .ToListAsync();

                //Kiểm tra lượng số lượng
                var currentQuantity = await _context.ImportDetails
                    .Where(d => d.ImportId == id)
                    .SumAsync(d => d.Quantity);
                var inventoryQuantity = await _context.Inventories
                    .Where(i => i.WarehouseId == request.WarehouseId)
                    .SumAsync(i => i.Quantity);
                var warehouse = await _context.Warehouses.FindAsync(request.WarehouseId);

                if (warehouse == null)
                    return BadRequest(Message.WarehouseNotFound);

                if (currentQuantity + inventoryQuantity > warehouse.MaxStock)
                    return BadRequest(Message.ExceedingQuantity);

                    //Cập nhật số lượng Inventory
                    foreach (var detail in importDetails)
                    {
                        //Inventory
                        var inventory = await _context.Inventories.Where(
                            i => i.ProductId == detail.ProductId
                            && i.WarehouseId == request.WarehouseId
                            && i.IsActive == true)
                            .FirstOrDefaultAsync();

                        if (inventory != null)
                        {
                            inventory.Quantity += detail.Quantity;
                            inventory.UpdatedAt = DateTime.Now;
                        }
                        else
                        {
                            inventory = new Inventory
                            {
                                ProductId = detail.ProductId,
                                WarehouseId = request.WarehouseId,
                                Quantity = detail.Quantity,
                                IsActive = true,
                                CreatedAt = DateTime.Now
                            };
                            _context.Inventories.Add(inventory);
                        }

                        ///Inventory Log
                        var log = new InventoryLog
                        {
                            Inventory = inventory,
                            Type = InventoryLogType.Import,
                            Description = request.Description,
                            Quantity = currentQuantity,
                            UserId = request.UserId,
                            Code = request.Code,
                            IsActive = true,
                            CreatedAt = DateTime.Now
                        };
                        _context.InventoryLogs.Add(log);
                    }
            }

            await _context.SaveChangesAsync();
            return Ok(Message.ImportUpdate);
        }
    }
}
