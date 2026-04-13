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
                Console.WriteLine($"[LOGIN] Nhận request: Username = {request?.Username}");

                if (request == null || string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                {
                    return BadRequest("Username và Password không được để trống");
                }

                var user = await _context.Users
                    .FirstOrDefaultAsync(x => x.Username == request.Username);

                Console.WriteLine($"[LOGIN] Tìm user: {(user != null ? "Tìm thấy" : "Không tìm thấy")}");

                if (user == null)
                    return BadRequest(Message.UserNotFound);

                // Kiểm tra mật khẩu
                bool isPasswordValid = false;

                try
                {
                    if (user.Password.StartsWith("$2a$") || user.Password.StartsWith("$2b$") || user.Password.StartsWith("$2y$"))
                    {
                        isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);
                    }
                    else
                    {
                        isPasswordValid = request.Password == user.Password; // fallback cho password plain
                    }
                }
                catch (Exception bcEx)
                {
                    Console.WriteLine($"[LOGIN] Lỗi BCrypt: {bcEx.Message}");
                    return BadRequest("Lỗi kiểm tra mật khẩu. Password trong DB có thể không đúng format.");
                }

                if (!isPasswordValid)
                    return BadRequest(Message.InvalidPassword);

                var token = _jwtService.GenerateToken(user);

                Console.WriteLine($"[LOGIN] Đăng nhập thành công: {user.Username}");

                return Ok(new
                {
                    token,
                    user = new
                    {
                        user.Id,
                        user.Username,
                        user.RoleId
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("=== LỖI LOGIN CONTROLLER ===");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                Console.WriteLine("===============================");

                return StatusCode(500, new { error = "Lỗi server nội bộ", detail = ex.Message });
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