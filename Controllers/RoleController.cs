using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_Warehouse.Common;
using Smart_Warehouse.Data;
using Smart_Warehouse.Models.Entities;
using Smart_Warehouse.Models.Respones.Role;

namespace Smart_Warehouse.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RoleController : ControllerBase
    {
        readonly DatabaseContext _context;
        readonly IMapper _mapper;

        public RoleController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/roles
        [HttpGet]
        public async Task<ActionResult<List<RoleResponse>>> GetAllRoles()
        {
            var roles = await _context.Roles
                .Where(x => x.IsActive)
                .Include(x => x.Users)
                .ToListAsync();

            var response = _mapper.Map<List<RoleResponse>>(roles);
            
            return Ok(response);
        }
    }
}
