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
        /// Trạng thái hoạt động của nhà kho
        /// </summary>
        public bool? WarehouseIsActive { get; set; }
        
        /// <summary>
        /// Id sản phẩm
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        public string? ProductName { get; set; }

        /// <summary>
        /// Trạng thái hoạt động của sản phẩm
        /// </summary>
        public bool? ProductIsActive { get; set; }

        /// <summary>
        /// Số lượng nhỏ nhất
        /// </summary>
        public int minQuantity {  get; set; }

        /// <summary>
        /// Số lượng tồn kho hiện tại của sản phẩm trong nhà kho
        /// </summary>
        public int Quantity { get; set; } = 0;

        /// <summary>
        /// Danh sách log
        /// </summary>
        public virtual List<InventoryLogResponse> Logs { get; set; } = new  ();
    }
}
