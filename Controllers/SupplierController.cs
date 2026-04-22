using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_Warehouse.Common;
using Smart_Warehouse.Data;
using Smart_Warehouse.Models.Entities;
using Smart_Warehouse.Models.Requests.Supplier;
using Smart_Warehouse.Models.Respones.Supplier;

namespace Smart_Warehouse.Controllers
{
    [ApiController]
    [Route("api/suppliers")]
    public class SupplierController : Controller
    {
        readonly DatabaseContext _context;
        readonly IMapper _mapper;

        public SupplierController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<List<SupplierResponse>>> GetAllSuppliers()
        {
            var suppliers = await _context.Suppliers.ToListAsync();

            var response = _mapper.Map<List<SupplierResponse>>(suppliers);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierResponse>> GetSupplierById(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null )
                return NotFound(Message.SupplierNotFound);

            var response = _mapper.Map<SupplierResponse>(supplier);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSupplier([FromBody] CreateSupplierRequest request)
        {
            var existingSupplier = await _context.Suppliers
                .FirstOrDefaultAsync(x => x.Name.ToLower() == request.Name.ToLower() && x.IsActive);
            if (existingSupplier != null)
                return BadRequest(Message.SupplierAlreadyExists);

            var supplier = _mapper.Map<Supplier>(request);
            supplier.IsActive = true;
            supplier.CreatedAt = DateTime.UtcNow;

            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();

            return Ok(supplier);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateSupplier(int id, [FromBody] UpdateSupplierRequest request)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null || !supplier.IsActive)
                return NotFound(Message.SupplierNotFound);
            if (await _context.Suppliers.AnyAsync(x => x.Id != id && x.Name.ToLower() == request.Name.ToLower() && x.IsActive))
                return BadRequest(Message.SupplierAlreadyExists);

            var response = _mapper.Map(request, supplier);
            supplier.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSupplier(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null || !supplier.IsActive)
                return NotFound(Message.SupplierNotFound);

            supplier.IsActive = false;
            supplier.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return Ok(Message.SupplierDeleted);
        }
    }
}
