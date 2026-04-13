using Smart_Warehouse.Models.Entities;

namespace Smart_Warehouse.Models.Respones.User
{
    public class UserResponse
    {
        /// <summary>
        /// Id người dùng
        /// </summary>
        public int Id { get; set; }
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
        /// Tên vai trò
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Hoạt động
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Ngày giờ tạo
        /// </summary>
        public DateTime CreatedAt { get; set; }

    }
}
