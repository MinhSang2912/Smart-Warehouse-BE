using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Smart_Warehouse.Data;
using Smart_Warehouse.Models.Requests.Auth;
using Smart_Warehouse.Common;
using System.Security.Claims;
using BCrypt.Net;

namespace Smart_Warehouse.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _config;
        private readonly JwtService _jwtService;

        public AuthController(DatabaseContext context, JwtService jwtService, IConfiguration config)
        {
            _context = context;
            _config = config;
            _jwtService = jwtService;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                if (request == null || string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                {
                    return BadRequest("Username và Password không được để trống");
                }

                var user = await _context.Users
                    .FirstOrDefaultAsync(x => x.Username == request.Username);

                if (user == null)
                    return BadRequest(Message.UserNotFound);

                bool isPasswordValid = false;

                // Ưu tiên kiểm tra BCrypt (định dạng chuẩn)
                if (user.Password.StartsWith("$2") && user.Password.Length > 50)
                {
                    try
                    {
                        isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);
                    }
                    catch
                    {
                        isPasswordValid = false;
                    }
                }
                else
                {
                    // Fallback cho trường hợp mật khẩu plain text (chỉ dùng tạm thời)
                    isPasswordValid = request.Password == user.Password;

                    // Nếu đăng nhập thành công bằng plain text → tự động hash lại mật khẩu
                    if (isPasswordValid)
                    {
                        user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
                        await _context.SaveChangesAsync();
                        Console.WriteLine($"[LOGIN] Đã tự động hash lại mật khẩu cho user: {user.Username}");
                    }
                }

                if (!isPasswordValid)
                    return BadRequest(Message.InvalidPassword);

                var token = _jwtService.GenerateToken(user);

                Console.WriteLine($"[LOGIN] Đăng nhập thành công: {user.Username} - RoleId: {user.RoleId}");

                return Ok(new
                {
                    token,
                    user = new
                    {
                        user.Id,
                        user.Username,
                        user.RoleId,
                        user.FullName   // nếu có
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("=== LỖI LOGIN CONTROLLER ===");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                return StatusCode(500, new { error = "Lỗi server nội bộ" });
            }
        }

        [HttpPut("reset-password")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Username == request.Username);
            if (user == null)
                return BadRequest(Message.UserNotFound);
            user.Password = _config["DefaultPassword:ResetPassword"]; 
            //user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return Ok(Message.PasswordChange);
        }

        [HttpPut("change-password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var userId = User.FindFirstValue("UserId");
            if (userId == null)
                return Unauthorized(Message.Unauthorized);
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Id == int.Parse(userId));
            if (user == null)
                return BadRequest(Message.UserNotFound);

            //Kiểm tra mật khẩu hiện tại
            bool isPasswordValid = false;
            if (user.Password.StartsWith("$2a$") || user.Password.StartsWith("$2b$") || user.Password.StartsWith("$2y$"))
            {
                isPasswordValid = BCrypt.Net.BCrypt.Verify(request.CurrentPassword, user.Password);
            }
            else
            {
                isPasswordValid = request.CurrentPassword == user.Password;
            }
            if (!isPasswordValid)
                return BadRequest(Message.InvalidPassword);

            user.Password = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
            user.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return Ok(Message.PasswordChange);
        }
        }
}