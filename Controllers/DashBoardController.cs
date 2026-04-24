using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_Warehouse.Common;
using Smart_Warehouse.Data;
using Smart_Warehouse.Models.Respones.DashBoard;
using Smart_Warehouse.Models.Respones.Inventory;
using static Smart_Warehouse.Common.Enums;

namespace Smart_Warehouse.Controllers
{
    [ApiController]
    [Route("api/dashboard")]
    public class DashBoardController : ControllerBase
    {
        readonly DatabaseContext _context;
        readonly IMapper _mapper;

        public DashBoardController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("stats")]
        public async Task<ActionResult<DashBoardStatsResponse>> GetStats(int warehouseId)
        {
            var today = DateTime.UtcNow.Date;
            var tomorrow = today.AddDays(1);
            var yesterday = today.AddDays(-1);

            var response = new DashBoardStatsResponse();
            response.TotalTodayReceipts = await _context.InventoryLogs
                .Where(l => l.Inventory.WarehouseId == warehouseId)
                .Where(l => l.CreatedAt >= today && l.CreatedAt <= tomorrow)
                .CountAsync();

            response.TotalYesterdayReceipt = await _context.InventoryLogs
                .Where(l => l.Inventory.WarehouseId == warehouseId)
                .Where(l => l.CreatedAt <= today && l.CreatedAt >= yesterday)
                .CountAsync();
            response.TodayImportReceipt = await _context.InventoryLogs
                .Where(l => l.Inventory.WarehouseId == warehouseId)
                .Where(l => l.CreatedAt >= today && l.CreatedAt <= tomorrow)
                .Where(l => l.Type == InventoryLogType.Import)
                .CountAsync();

            response.TodayExportReceipt = await _context.InventoryLogs
                .Where(l => l.Inventory.WarehouseId == warehouseId)
                .Where(l => l.CreatedAt >= today && l.CreatedAt <= tomorrow)
                .Where(l => l.Type == InventoryLogType.Export)
                .CountAsync();

            response.TotalLowStock = await _context.Inventories
                .Where(i => i.WarehouseId == warehouseId)
                .Include(i => i.Product)
                .Where(i => i.Warehouse.IsActive == true)
                .Where(i => i.Quantity < i.Product.MinThreshold && i.Product.IsActive == true)
                .CountAsync();

            return Ok(response);
        }

        [HttpGet("product-stock")]
        public async Task<ActionResult<List<DashBoardStockResponse>>> GetProductStock(int warehouseId)
        {
            var warehouse = await _context.Warehouses.FindAsync(warehouseId);

            if (warehouse == null || warehouse.IsActive == false)
                return NotFound(Message.WarehouseNotFound);

            var inventory = await _context.Inventories
                .Include(i => i.Product)
                .Where(i => i.WarehouseId == warehouseId)
                .Where(i => i.Product.IsActive == true)
                .Where(i => i.Quantity != 0)
                .ToListAsync();

            var response = new List<DashBoardStockResponse>();

            foreach (var item in inventory)
            {
                var stock = new DashBoardStockResponse
                {
                    ProductName = item.Product.Name,
                    ProductId = item.ProductId,
                    ProductSku = item.Product.SKU,
                    CurrentStock = item.Quantity
                };
                response.Add(stock);
            }

            return Ok(response);
            
        }

        [HttpGet("import-export")]
        public async Task<ActionResult<List<DashBoardImportExportResponse>>> GetImportExport (int warehouseId, int month)
        {
            if (month == 0)
                month = DateTime.UtcNow.Month;

            var warehouse = await _context.Warehouses.FindAsync(warehouseId);
            if (warehouse == null || warehouse.IsActive == false)
                return NotFound(Message.WarehouseNotFound);

            var today = DateTime.Now;
            var firstDayOfMonth = new DateTime(DateTime.Now.Year, month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            var currentDay = firstDayOfMonth;

            var logs = await _context.InventoryLogs
                .ToListAsync();
            var response = new List<DashBoardImportExportResponse>();
            
            while (currentDay<=lastDayOfMonth && currentDay < today)
            {
                var item = new DashBoardImportExportResponse();
                item.Day = currentDay.Day;
                item.ImportQuantity = await _context.InventoryLogs
                    .Where(i => i.CreatedAt > currentDay && i.CreatedAt < currentDay.AddDays(5))
                    .Where(i => i.Type == InventoryLogType.Import)
                    .Where(i => i.Inventory.WarehouseId == warehouseId)
                    .SumAsync(i => i.Quantity);

                item.ExportQuantity = await _context.InventoryLogs
                    .Where(i => i.CreatedAt > currentDay && i.CreatedAt < currentDay.AddDays(5))
                    .Where(i => i.Type == InventoryLogType.Export)
                    .Where(i => i.Inventory.WarehouseId == warehouseId)
                    .SumAsync (i => i.Quantity);
                response.Add(item);
                currentDay = currentDay.AddDays(5);
            }

            return Ok(response);
        }
    }
}
