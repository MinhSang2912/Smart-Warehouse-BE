namespace Smart_Warehouse.Models.Entities
{
    /// <summary>
    /// Đại diện cho người dùng của hệ thống Smart Warehouse.
    /// Dùng để quản lý tài khoản, phân quyền và theo dõi hoạt động nhập/xuất kho.
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// Tên đăng nhập
        /// </summary>
        public required string Username { get; set; } 

        /// <summary>
        /// Mật khẩu đã được
        /// </summary>
        public required string Password { get; set; }

        /// <summary>
        /// Tên đầy đủ của người dùng.
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// Địa chỉ email của người dùng 
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Số điện thoại liên hệ.
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// Ngày tháng năm sinh 
        /// </summary>
        public DateTime? DateofBirth { get; set; }

        /// <summary>
        /// Id của vai trò
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Khóa ngoại đến vai trò của người dùng
        /// </summary>
        public virtual Role? Role { get; set; } = null;
    }
}