using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_Warehouse.Common;
using Smart_Warehouse.Data;
using Smart_Warehouse.Models.Entities.Inventories;
using Smart_Warehouse.Models.Requests.Inventory;
using Smart_Warehouse.Models.Respones.Inventory;

namespace Smart_Warehouse.Controllers
{
    [ApiController]
    [Route("api/inventories")]
    public class InventoryController : ControllerBase
    {
        readonly DatabaseContext _context;
        readonly IMapper _mapper;

        public InventoryController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<InventoryResponse>>> GetAllInventory()
        {
            var inventory = await _context.Inventories
                .Include(i => i.Warehouse)
                .Include(i => i.Product)
                .Where(i =>  !(i.Quantity == 0 && i.Product.Supplier.IsActive == false))
                .ToListAsync();
            



            var response = _mapper.Map<List<InventoryResponse>>(inventory);
            
            return Ok(response);
        }


        [HttpGet("product/{productId}/warehouse/{warehouseId}")]
        public async Task<ActionResult<InventoryResponse>> GetInventoryById(Guid ProductId, int WarehouseId)
        {
            var inventory = await _context.Inventories.FirstOrDefaultAsync(i=>i.ProductId == ProductId && i.WarehouseId == WarehouseId);
            if (inventory == null)
                return NotFound(Message.InventoryNotFound);

            var response = _mapper.Map<InventoryResponse>(inventory);
            return Ok(response);
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateInventory([FromBody] UpdateInventoryRequest request)
        {
            var inventory = await _context.Inventories.FirstOrDefaultAsync(i => i.WarehouseId == request.WarehouseId && i.ProductId == request.ProductId);

            var warehouse = await _context.Warehouses.FindAsync(request.WarehouseId);
            var isMaxStock = request.Quantity > warehouse?.MaxStock;
            if(isMaxStock == true)
            {
                return BadRequest(Message.MaxStockExceeded);
            }

            var msg ="";
            if (inventory != null && inventory.IsActive == true)
            {
                _mapper.Map(request, inventory);
                inventory.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                msg = "Cập nhật thành công";
            }
            else
            {
                inventory = _mapper.Map<Inventory>(request);
                inventory.CreatedAt = DateTime.UtcNow;
                inventory.IsActive = true;
                _context.Inventories.Add(inventory);
                await _context.SaveChangesAsync();
                msg = "Thêm thành công";
            }

            return Ok(msg);
        }

        //[HttpPatch]
        //public async Task<ActionResult> UpdateInventory([FromBody] UpdateInventoryRequest request)
        //{
        //    var inventory = await _context.Inventories.FirstOrDefaultAsync(i => i.WarehouseId == request.WarehouseId && i.ProductId == request.ProductId);
        //    if (inventory == null)
        //        return NotFound(Message.InventoryNotFound);

        //    var response = _mapper.Map(request, inventory);
        //    inventory.UpdatedAt = DateTime.UtcNow;

        //    await _context.SaveChangesAsync();

        //    return Ok(response);
        //}

        [HttpDelete]
        public async Task<ActionResult> DeleteInventory(UpdateInventoryRequest request)
        {
            var inventory = await _context.Inventories.FirstOrDefaultAsync(i => i.WarehouseId == request.WarehouseId && i.ProductId == request.ProductId && i.IsActive == true);
            if (inventory == null)
            {
                return NotFound(Message.InventoryNotFound);
            }
            
            inventory.IsActive = false;
            inventory.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return Ok(Message.InventoryDeleted);
        }
    }
}
