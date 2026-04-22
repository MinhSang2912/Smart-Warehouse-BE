using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_Warehouse.Common;
using Smart_Warehouse.Data;
using Smart_Warehouse.Models.Entities;
using Smart_Warehouse.Models.Requests.Category;
using Smart_Warehouse.Models.Respones.Category;

namespace Smart_Warehouse.Controllers
{
    [ApiController]
    [Route("api/categories")]

    public class CategoryController : ControllerBase
    {
        readonly DatabaseContext _context;
        readonly IMapper _mapper;

        public CategoryController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryResponse>>> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();

            var response = _mapper.Map<List<CategoryResponse>>(categories);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResponse>> GetCategoryById(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null || !category.IsActive)
                return NotFound(Message.CategoryNotFound);

            var response = _mapper.Map<CategoryResponse>(category);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
        {
            var existingCategory = await _context.Categories
                .FirstOrDefaultAsync(x => x.Name.ToLower() == request.Name.ToLower() && x.IsActive);
            if (existingCategory != null)
                return BadRequest(Message.CategoryAlreadyExists);

            var category = _mapper.Map<Category>(request);
            category.IsActive = true;
            category.CreatedAt = DateTime.UtcNow;

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return Ok(category);
        }


        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryRequest request)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null || !category.IsActive)
                return NotFound(Message.CategoryNotFound);

            category = _mapper.Map(request, category);
            category.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null    )
                return NotFound(Message.CategoryNotFound);

            category.IsActive = false;
            category.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return Ok(Message.CategoryDeleted);
        }
    }
}
