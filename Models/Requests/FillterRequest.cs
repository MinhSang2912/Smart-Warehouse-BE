using static Smart_Warehouse.Common.Enums;

namespace Smart_Warehouse.Models.Requests
{
    public class FillterRequest
    {
        public Status? status { get; set; } = Status.All;
        public DateTime? date { get; set; } = null;
        public string? warehouse { get; set; } = null;
    }
}
