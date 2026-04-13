namespace Smart_Warehouse.Models.Requests.Auth
{
    public class ResetPasswordRequest
    {
        /// <summary>
        /// Tên đăng nhập
        /// </summary>
        public string Username { get; set; } = null!;
    }
}
