using Smart_Warehouse.Common;
using static Smart_Warehouse.Common.Enums;

namespace Smart_Warehouse.Models.Requests.Export
{
    public class UpdateExportRequest
    {
        public int UserId { get; set; }
        public int WarehouseId { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; } = Status.Pending;
    }
}
