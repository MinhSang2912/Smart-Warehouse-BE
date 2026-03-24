namespace Smart_Warehouse.Models.Entities
{
    /// <summary>
    /// Đại diện cho một nhà cung cấp (Supplier) trong hệ thống quản lý kho thông minh.
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// Khóa chính của nhà cung cấp (sử dụng Guid để dễ đồng bộ và import dữ liệu).
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Tên đầy đủ của nhà cung cấp (ví dụ: Công ty TNHH Samsung Việt Nam, Apple Inc...).
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Tên viết tắt hoặc tên thương hiệu thường dùng.
        /// </summary>
        public string? ShortName { get; set; }

        /// <summary>
        /// Mã nhà cung cấp (Supplier Code) - thường do công ty tự đặt.
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Số điện thoại liên hệ chính.
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// Địa chỉ email liên hệ.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Địa chỉ văn phòng / kho của nhà cung cấp.
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Tên người đại diện / nhân viên liên hệ.
        /// </summary>
        public string? ContactPerson { get; set; }

        /// <summary>
        /// Ghi chú thêm về nhà cung cấp (điều khoản thanh toán, ưu đãi, đánh giá...).
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// Trạng thái hoạt động của nhà cung cấp.
        /// False = đã ngừng hợp tác.
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Thời điểm tạo thông tin nhà cung cấp.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Thời điểm cập nhật thông tin nhà cung cấp lần cuối.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        // ==================== Navigation Properties ====================

        /// <summary>
        /// Danh sách sản phẩm mà nhà cung cấp này cung cấp (Navigation Property).
        /// </summary>
        public ICollection<Product> Products { get; set; } = new List<Product>();

        /// Danh sách đơn đặt hàng từ nhà cung cấp này.
        
        }
}