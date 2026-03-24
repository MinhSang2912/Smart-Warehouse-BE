namespace Smart_Warehouse.Models.Entities
{
    /// <summary>
    /// Đại diện cho người dùng của hệ thống Smart Warehouse.
    /// Dùng để quản lý tài khoản, phân quyền và theo dõi hoạt động nhập/xuất kho.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Khóa chính của người dùng (sử dụng Guid để dễ dàng quản lý và đồng bộ).
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Tên đăng nhập (Username) - dùng để đăng nhập hệ thống.
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Mật khẩu đã được hash (không lưu mật khẩu dạng plain text).
        /// </summary>
        public string PasswordHash { get; set; } = string.Empty;

        /// <summary>
        /// Tên đầy đủ của người dùng.
        /// </summary>
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Địa chỉ email của người dùng (dùng để khôi phục mật khẩu, nhận thông báo).
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Số điện thoại liên hệ.
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// Vai trò của người dùng trong hệ thống (Admin, WarehouseStaff, Manager...).
        /// </summary>
        public string Role { get; set; } = "WarehouseStaff";   // Admin, Manager, Staff

        /// <summary>
        /// Trạng thái tài khoản. False = tài khoản đã bị khóa.
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Thời điểm tài khoản được tạo.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Thời điểm cập nhật thông tin người dùng lần cuối.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Thời điểm lần cuối đăng nhập thành công (dùng để theo dõi hoạt động).
        /// </summary>
        public DateTime? LastLoginAt { get; set; }

        // ==================== Navigation Properties ====================

        /// <summary>
        /// Danh sách các giao dịch nhập/xuất kho do người dùng này thực hiện.
        /// </summary>
    }
}