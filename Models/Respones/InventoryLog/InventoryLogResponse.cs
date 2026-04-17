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
        public string? Description { get; set; }

        /// <summary>
        /// Id người dùng thực hiện hoạt động
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Tên người dùng
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// Thời gian tạo
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Code của phiếu
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Sô lượng của phiếu
        /// </summary>
        public int Quantity { get; set; }
    }
}
