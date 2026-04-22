using Smart_Warehouse.Models.Respones.ExportDetail;
using static Smart_Warehouse.Common.Enums;

namespace Smart_Warehouse.Models.Respones.Export
{
    public class ExportResponse
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public int WarehouseId { get; set; }
        public string? WarehouseName { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; }
        public string StatusDisplay => Status.GetDisplayName(); 
        public DateTime CreatedAt { get; set; }
        public virtual List<ExportDetailResponse> Details { get; set; } = new();
    }
}
