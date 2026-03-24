namespace Smart_Warehouse.Models.Entities
{
    public class Catagory
    {
        /// <summary>
        /// Khóa chính của danh mục (sử dụng Guid để dễ dàng import và đồng bộ dữ liệu).
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Tên danh mục sản phẩm (ví dụ: Điện thoại, Laptop, Phụ kiện, Tai nghe, Sạc dự phòng...).
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Mô tả ngắn gọn về danh mục (tính chất, đối tượng sử dụng...).
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Mã viết tắt của danh mục (ví dụ: DT, LT, PK, TP, SAC...).
        /// Dùng để hiển thị ngắn, xuất Excel hoặc in báo cáo.
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Danh sách các sản phẩm thuộc danh mục này.
        /// </summary>
        public ICollection<Product> Products { get; set; } = new List<Product>();

        /// <summary>
        /// Trạng thái hoạt động của danh mục.
        /// False = danh mục đã ngừng sử dụng (không cho tạo sản phẩm mới).
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Thời điểm danh mục được tạo trong hệ thống.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Thời điểm cập nhật thông tin danh mục lần cuối.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
