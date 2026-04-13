using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_Warehouse.Data;
using Smart_Warehouse.Models.Entities.Inventories;
using Smart_Warehouse.Models.Requests.InventoryLog;
using Smart_Warehouse.Models.Respones.InventoryLog;
using static Smart_Warehouse.Common.Enums;

namespace Smart_Warehouse.Controllers
{
    [ApiController]
    [Route("api/inventory-logs")]
    public class InventoryLogController : ControllerBase
    {
        readonly DatabaseContext _context;
        readonly IMapper _mapper;

        public InventoryLogController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllInventoryLogs()
        {
            var inventoryLogs = await _context.InventoryLogs.ToListAsync();

            var response = _mapper.Map<List<InventoryLogResponse>>(inventoryLogs);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateInventoryLog([FromBody] CreateInventoryLogRequest request)
        {
            var inventoryLog = _mapper.Map<InventoryLog>(request);
            inventoryLog.IsActive = true;
            inventoryLog.CreatedAt = DateTime.UtcNow;

            _context.InventoryLogs.Add(inventoryLog);
            await _context.SaveChangesAsync();

            return Ok(inventoryLog);
        }
    }
}
