namespace Smart_Warehouse.Models.Requests.User
{
    public class CreateUserRequest
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
    }
}
