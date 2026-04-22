using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_Warehouse.Common;
using Smart_Warehouse.Data;
using Smart_Warehouse.Models.Entities;
using Smart_Warehouse.Models.Requests.User;
using Smart_Warehouse.Models.Respones.User;
using System.Net.WebSockets;

namespace Smart_Warehouse.Controllers
{
    [ApiController]
    [Route("api/users")]
    //[Authorize(Roles = "1")]
    public class UserController : ControllerBase
    {
        readonly DatabaseContext _context;
        readonly IMapper _mapper;

        public UserController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserResponse>>> GetAllUsers()
        {
            var users = await _context.Users
                .Include(x => x.Role)
                .ToListAsync();

            var results = _mapper.Map<List<UserResponse>>(users);
            

            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null || !user.IsActive)
                return NotFound(Message.UserNotFound);

            var role = await _context.Roles.FindAsync(user.RoleId);
            var result = _mapper.Map<UserResponse>(user);
            result.RoleName = role.Name;

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateUserRequest request)
        {
            if (request.Username == null)
                return BadRequest(Message.UserNotFound);
            if (request.Password == null)
                return BadRequest(Message.PasswordNotNull);

            if (await _context.Users.AnyAsync(x => x.Username == request.Username))
                return BadRequest(Message.UserAlreadyExists);

            var user = _mapper.Map<User>(request);
            user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.CreatedAt = DateTime.UtcNow;
            user.IsActive = true;

            _context.Users.Add(user);

            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(int Id, [FromBody] UpdateUserRequest request)
        {
            var user = await _context.Users.FindAsync(Id);
            if (user == null || !user.IsActive)
                return NotFound(Message.UserNotFound);

            _mapper.Map(request, user);
            user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return Ok(Message.UserUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null || !user.IsActive)
                return NotFound(Message.UserNotFound);

            user.IsActive = false;
            user.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return Ok(Message.UserDeleted);
        }
    }
}
