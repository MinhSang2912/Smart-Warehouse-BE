using static Smart_Warehouse.Common.Enums;

namespace Smart_Warehouse.Models.Respones.InventoryLog
{
    public class InventoryLogResponse
    {
        /// <summary>
        /// Id tồn kho
        /// </summary>
        public int InventoryId { get; set; }

        /// <summary>
        /// Loại hoạt động
        /// </summary>
        public InventoryLogType Type { get; set; }

        /// <summary>
        /// Lý do
        /// </summary>
        public string? Reason { get; set; }

        /// <summary>
        /// Id người dùng thực hiện hoạt động
        /// </summary>
        public int UserId { get; set; }
    }
}
