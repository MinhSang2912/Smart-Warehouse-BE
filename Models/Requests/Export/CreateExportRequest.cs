using Smart_Warehouse.Common;
using Smart_Warehouse.Models.Requests.ExportDetail;
using static Smart_Warehouse.Common.Enums;

namespace Smart_Warehouse.Models.Requests.Export
{
    public class CreateExportRequest
    {
        public required string Code { get; set; }
        public int UserId { get; set; }
        public int WarehouseId { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; } = Status.Pending;
        public virtual ICollection<CreateExportDetailRequest> ExportDetails { get; set; } = new List<CreateExportDetailRequest>();
    }
}
