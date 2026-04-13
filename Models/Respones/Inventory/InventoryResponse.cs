using Smart_Warehouse.Models.Entities;
using Smart_Warehouse.Models.Respones.InventoryLog;

namespace Smart_Warehouse.Models.Respones.Inventory
{
    public class InventoryResponse : BaseEntity
    {
        /// <summary>
        /// Id nhà kho
        /// </summary>
        public int WarehouseId { get; set; }
        
        /// <summary>
        /// Tên nhà nho 
        /// </summary>
        public string? WarehouseName { get; set; }


        /// <summary>
        /// Id sản phẩm
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        public string? ProductName { get; set; }

        /// <summary>
        /// Số lượng nhỏ nhất
        /// </summary>
        public int minQuantity {  get; set; }

        /// <summary>
        /// Số lượng tồn kho hiện tại của sản phẩm trong nhà kho
        /// </summary>
        public int Quantity { get; set; } = 0;

        public virtual ICollection<InventoryLogResponse> InventoryLogs { get; set; } = new List<InventoryLogResponse>();
    }
}
