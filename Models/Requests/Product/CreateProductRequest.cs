using Smart_Warehouse.Models.Entities;

namespace Smart_Warehouse.Models.Requests.Product
{
    public class CreateProductRequest
    {
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
        /// Mã danh mục
        /// </summary>
        public int CategoryId { get; set; }

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
        /// Id nhà cung cấp
        /// </summary>
        public int SupplierId { get; set; }

    }
}
