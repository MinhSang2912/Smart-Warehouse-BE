using Smart_Warehouse.Models.Entities.Order;

namespace Smart_Warehouse.Models.Entities
{
    public class Product : BaseEntity
    {
        /// <summary>
        /// Id sản phẩm
        /// </summary>
        public new Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Code sản phẩm
        /// </summary>
        public string SKU { get; set; } = string.Empty;
        
        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Mô tả sản phẩm
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Cảnh báo thiếu hàng
        /// </summary>
        public int MinThreshold { get; set; } = 50; 

        /// <summary>
        /// Đơn vị tính
        /// </summary>
        public string Unit { get; set; } = "Cái";

        /// <summary>
        /// Giá sản phẩm
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Mã danh mục
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Khóa ngoại danh mục sản phẩm (Navigation Property)
        /// </summary>
        public virtual Category Category { get; set; } = null!;

        /// <summary>
        /// Id nhà cung cấp
        /// </summary>
        public int SupplierId { get; set; }

        /// <summary>
        /// Khóa ngoại nhà cung cấp (navigation property)
        /// </summary>
        public virtual Supplier Supplier { get; set; } = null!;

    }
}
