using Smart_Warehouse.Models.Entities;
using static Smart_Warehouse.Common.Enums;

namespace Smart_Warehouse.Models.Requests.InventoryLog
{
    public class CreateInventoryLogRequest
    {
        /// <summary>
        /// Id tồn kho
        /// </summary>
        public int InventoryId { get; set; }

        /// <summary>
        /// Loại hoạt động
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Lý do
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Id người dùng thực hiện hoạt động
        /// </summary>
        public int UserId { get; set; }
    }
}
