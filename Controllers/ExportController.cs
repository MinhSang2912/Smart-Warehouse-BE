using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_Warehouse.Common;
using Smart_Warehouse.Data;
using Smart_Warehouse.Models.Entities.Inventories;
using Smart_Warehouse.Models.Entities.Orders;
using Smart_Warehouse.Models.Requests.Export;
using Smart_Warehouse.Models.Respones.Export;
using static Smart_Warehouse.Common.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Smart_Warehouse.Controllers
{
    [ApiController]
    [Route("api/exports")]
    public class ExportController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public ExportController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/exports
        [HttpGet]
        public async Task<ActionResult<List<ExportResponse>>> GetAllExports()
        {
            var exports = await _context.Exports
                .Include(e => e.User)
                .Include(e => e.Details)
                .Where(e => e.IsActive)
                .OrderByDescending(e => e.CreatedAt)
                .ToListAsync();

            var responses = _mapper.Map<List<ExportResponse>>(exports);
            return Ok(responses);
        }

        // GET: api/exports/"id"
        //[HttpGet("id")]
        //public async Task<ActionResult<ExportResponse>> GetExportById(int id)
        //{
        //    var export = await _context.Exports
        //        .Include(e => e.User)
        //        .Include(e => e.Warehouse)
        //        .Include(e => e.Details)
        //        .FirstOrDefaultAsync(e => e.Id == id);

        //    if (export == null || !export.IsActive)
        //        return NotFound(Message.ExportNotFound);

        //    var response = _mapper.Map<ExportResponse>(export);
        //    return Ok(response);
        //}

        // POST: api/exports
        [HttpPost]
        public async Task<ActionResult> CreateExport([FromBody] CreateExportRequest request)
        {
            //Kiểm tra export
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null || user.IsActive != true) 
                return NotFound(Message.UserNotFound);

            var warehouse = await _context.Warehouses.FindAsync(request.WarehouseId);
            if (warehouse == null || warehouse.IsActive != true)
                return NotFound(Message.WarehouseNotFound);

            //Mapping export
            var export = _mapper.Map<Export>(request);
            export.CreatedAt = DateTime.UtcNow;
            export.IsActive = true;
            export.Status = Status.Pending;
            _context.Exports.Add(export);

            //Xử lý từng sản phẩm
            foreach (var detail in request.ExportDetails)
            {
                //Detail
                var product = await _context.Products
                    .Where(i => i.Id == detail.ProductId)
                    .FirstOrDefaultAsync();

                if (product == null || product.IsActive != true)
                    return NotFound(Message.ProductNotFound);
                
                if (detail.Quantity <= 0)
                    return BadRequest(Message.QuantityHigherZero);

                var exportDetail = _mapper.Map<ExportDetail>(detail);
                exportDetail.Export = export;
                _context.ExportDetails.Add(exportDetail);

                //Inventory
                var inventory = await _context.Inventories
                    .Where(i => i.ProductId == detail.ProductId && i.WarehouseId == request.WarehouseId)
                    .FirstAsync();

                if (inventory == null || inventory.IsActive != true)
                    return NotFound(Message.InventoryNotFound);

               if (inventory.Quantity - detail.Quantity < 0)
                    return BadRequest(Message.ExceedingQuantity);

                inventory.Quantity -= detail.Quantity;
                inventory.UpdatedAt = DateTime.Now;

                //InventoryLog
                var inventoryLog = new InventoryLog
                {
                    Inventory = inventory,
                    Type = InventoryLogType.Export,
                    Description = request.Description,
                    Code = request.Code,
                    UserId = request.UserId,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                };
                _context.InventoryLogs.Add(inventoryLog);
            }

            await _context.SaveChangesAsync();

            return Ok(Message.ExportCreated);
        }

        // PUT: api/exports/"id"
        [HttpPatch("id")]
        public async Task<ActionResult> UpdateExport(int id, [FromBody] UpdateExportRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var export = await _context.Exports.FindAsync(id);
            if (export == null || !export.IsActive)
                return NotFound(Message.ExportNotFound);

            var response = _mapper.Map(request, export);
            export.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok(response);
        }
    }
}
