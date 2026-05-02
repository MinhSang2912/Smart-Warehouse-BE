using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_Warehouse.Common;
using Smart_Warehouse.Data;
using Smart_Warehouse.Models.Entities;
using Smart_Warehouse.Models.Requests.Warehouse;
using Smart_Warehouse.Models.Respones.Warehouse;

namespace Smart_Warehouse.Controllers
{
    [ApiController]
    [Route("api/warehouses")]
    public class WarehouseController : ControllerBase
    {
        readonly DatabaseContext _context;
        readonly IMapper _mapper;

        public WarehouseController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<WarehouseResponse>>> GetAllWarehouses()
        {
            var warehouses = await _context.Warehouses.ToListAsync();

            var response = _mapper.Map<List<WarehouseResponse>>(warehouses);
            
            for (int i = 0; i < response.Count; i++)
            {
                response[i].CurrentStock = await _context.Inventories
                    .Where(p => p.WarehouseId == response[i].Id && p.IsActive)
                    .SumAsync(p => p.Quantity);
            }

            return Ok(response);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WarehouseResponse>> GetWarehouseById(int id)
        {
            var warehouse = await _context.Warehouses.FindAsync(id);
            if (warehouse == null || !warehouse.IsActive)
                return NotFound(Message.WarehouseNotFound);

            var response = _mapper.Map<WarehouseResponse>(warehouse);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateWarehouse([FromBody] CreateWarehouseRequest request)
        {
            var existingWarehouse = await _context.Warehouses
                .FirstOrDefaultAsync(x => x.Name.ToLower() == request.Name.ToLower() && x.IsActive);
            if (existingWarehouse != null)
                return BadRequest(Message.WarehouseAlreadyExists);

            var warehouse = _mapper.Map<Warehouse>(request);
            warehouse.IsActive = true;
            warehouse.CreatedAt = DateTime.UtcNow;

            _context.Warehouses.Add(warehouse);
            await _context.SaveChangesAsync();

            return Ok(warehouse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateWarehouse(int id, [FromBody] UpdateWarehouseRequest request)
        {
            if (request.Name == null)
                return BadRequest(Message.WarehouseNotFound);
            var warehouseIsExists = await _context.Warehouses.FindAsync(id);
            if (warehouseIsExists == null || !warehouseIsExists.IsActive)
                return NotFound(Message.WarehouseNotFound);
            if (await _context.Warehouses.AnyAsync(x => x.Id != id && x.Name.ToLower() == request.Name.ToLower() && x.IsActive))
                return BadRequest(Message.WarehouseAlreadyExists);

            var warehouse = _mapper.Map(request, warehouseIsExists);

            await _context.SaveChangesAsync();

            return Ok(warehouse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWarehouse(int id)
        {
            var warehouse = await _context.Warehouses.FindAsync(id);
            if (warehouse == null || !warehouse.IsActive)
                return NotFound(Message.WarehouseNotFound);

            warehouse.IsActive = false;

            await _context.SaveChangesAsync();
            return Ok(Message.WarehouseDeleted);
        }
    }
}
