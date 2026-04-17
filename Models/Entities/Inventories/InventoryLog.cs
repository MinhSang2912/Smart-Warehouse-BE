using static Smart_Warehouse.Common.Enums;

namespace Smart_Warehouse.Models.Entities.Inventories
{
    public class InventoryLog : BaseEntity
    {
        /// <summary>
        /// Id tồn kho
        /// </summary>
        public int InventoryId { get; set; }

        /// <summary>
        /// Khóa ngoại vào tồn kho nào (Navigation Property)
        /// </summary>
        public virtual Inventory Inventory { get; set; } = null!;

        /// <summary>
        /// Code của phiếu
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Số lượng thay đổi
        /// </summary>
        public int Quantity { get; set; } = 0;

        /// <summary>
        /// Loại hoạt động
        /// </summary>
        public InventoryLogType Type { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Id người dùng thực hiện hoạt động
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Khóa ngoại vào người dùng nào (Navigation Property)
        /// </summary>
        public virtual User User { get; set; } = null!;
    }
}
