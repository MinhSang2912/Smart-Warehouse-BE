namespace Smart_Warehouse.Models.Entities.Inventories
{
    public class Inventory : BaseEntity
    {
        /// <summary>
        /// Id nhà kho
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// Phụ thuôc nhà kho (Navigation Property)
        /// </summary>
        public virtual Warehouse Warehouse { get; set; } = null!;

        /// <summary>
        /// Id sản phẩm
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Khóa ngoại sản phẩm (Navigation Property)
        /// </summary>
        public virtual Product Product { get; set; } = null!;

        /// <summary>
        /// Số lượng tồn kho hiện tại của sản phẩm trong nhà kho
        /// </summary>
        public int Quantity { get; set; } = 0;

        /// <summary>
        /// Các bản ghi lịch sử
        /// </summary>

        public virtual ICollection<InventoryLog> Logs { get; set; } = new List<InventoryLog>();
    }
}
