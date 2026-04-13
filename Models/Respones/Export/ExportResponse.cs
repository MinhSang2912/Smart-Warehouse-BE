using static Smart_Warehouse.Common.Enums;

namespace Smart_Warehouse.Models.Respones.Export
{
    public class ExportResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WarehouseId { get; set; }
        public string? Description { get; set; }
        public Status status { get; set; }
    }
}
