using Smart_Warehouse.Models.Entities;

namespace Smart_Warehouse.Models.Respones.Product
{
    public class ProductResponse : BaseEntity
    {
        public new Guid Id { get; set; } 
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
        /// Tên danh mục
        /// </summary>
        public string? CategoryName { get; set; }

        /// <summary>
        /// Cảnh báo thiếu hàng
        /// </summary>
        public int MinThreshold { get; set; }

        /// <summary>
        /// Đơn vị tính
        /// </summary>
        public string Unit { get; set; } = "Cái";

        /// <summary>
        /// Giá sản phẩm
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Tên nhà cung cấp
        /// </summary>
        public string SupplierName { get; set; } = "";
    }
}
