using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_Warehouse.Common;
using Smart_Warehouse.Data;
using Smart_Warehouse.Models.Entities;
using Smart_Warehouse.Models.Requests.Product;
using Smart_Warehouse.Models.Respones.Product; 
namespace Smart_Warehouse.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public ProductController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<List<ProductResponse>>> GetAllProducts()
        {
            var products = await _context.Products
                .Include(p => p.Category)      
                .Include(p => p.Supplier)      
                .ToListAsync();

            
            var results = _mapper.Map<List<ProductResponse>>(products);
            return Ok(results);
        }

        // GET: api/Product/"{id}"
        [HttpGet("{id}")]                     
        public async Task<ActionResult<ProductResponse>> GetProductById(Guid id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(x => x.Id == id );

            if (product == null)
                return NotFound(Message.ProductNotFound);

            var result = _mapper.Map<ProductResponse>(product);
            return Ok(result);
        }

        // Get: api/Product/by-supplier/"{id}" 
        [HttpGet ("by-supplier/{id}")]
        public async Task<ActionResult<List<ProductResponse>>> GetProductBySupplier(int id)
        {
            var supllier = await _context.Suppliers.FirstOrDefaultAsync(s => s.Id == id && s.IsActive);
            if (supllier == null)
                return NotFound(Message.SupplierNotFound);

            var products = await _context.Products
                .Where(p => p.SupplierId == id)
                .Where(p => p.IsActive == true)
                .ToListAsync();
            if (products.Count == 0)
                return NotFound(Message.ProductNotFound);

            var response = _mapper.Map<List<ProductResponse>>(products);

            return Ok(response);
        }

        // Get: api/Product/by-warehouse/"{id}" 
        [HttpGet ("by-warehouse/{id}")]
        public async Task<ActionResult<List<ProductResponse>>> GetByWarehouse (int id)
        {
            // Kiểm tra tồn tại kho
            var warehouse = await _context.Warehouses.FindAsync(id);
            if (warehouse == null || warehouse.IsActive != true)
                return NotFound(Message.WarehouseNotFound);


            // Lấy danh sách sản phẩm trong kho
            var inventories = await _context.Inventories
                .Where(i => i.WarehouseId == id && i.IsActive == true)
                .Include(i => i.Product)
                .ToListAsync();

            if (inventories.Count == 0)
                return NotFound(Message.InventoryNotFound);

            // Lấy sản phẩm từ inventory và lọc những sản phẩm đang hoạt động
            var product = inventories
                .Select(i => i.Product)
                .Where(p => p.IsActive)
                .ToList();

            if (product.Count == 0)
                return NotFound(Message.ProductNotFound);

            var response = _mapper.Map<List<ProductResponse>>(product);

            return Ok(response);
        }

        // POST: api/Product
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateProductRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Kiểm tra tồn tại
            if (await _context.Products.AnyAsync(x => x.SKU == request.SKU && x.IsActive))
                return BadRequest(Message.ProductAlreadyExists);

            if (!await _context.Categories.AnyAsync(x => x.Id == request.CategoryId && x.IsActive))
                return BadRequest(Message.CategoryNotFound);

            if (!await _context.Suppliers.AnyAsync(x => x.Id == request.SupplierId && x.IsActive))
                return BadRequest(Message.SupplierNotFound);

            if (request.Price < 0)
                return BadRequest(Message.PriceMustBePositive);

            var product = _mapper.Map<Product>(request);
            product.CreatedAt = DateTime.UtcNow;
            product.IsActive = true;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }

        // PUT: api/Product/"{id}" 
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateProductRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await _context.Products.FindAsync(id);
            if (product == null || !product.IsActive)
                return NotFound(Message.ProductNotFound);

            // Kiểm tra SKU trùng (trừ chính nó)
            if (await _context.Products.AnyAsync(x => x.SKU == request.SKU && x.Id != id && x.IsActive))
                return BadRequest(Message.ProductAlreadyExists);

            if (!await _context.Categories.AnyAsync(x => x.Id == request.CategoryId && x.IsActive))
                return BadRequest(Message.CategoryNotFound);

            if (!await _context.Suppliers.AnyAsync(x => x.Id == request.SupplierId && x.IsActive))
                return BadRequest(Message.SupplierNotFound);

            if (request.Price < 0)
                return BadRequest(Message.PriceMustBePositive);

            var response = _mapper.Map(request, product);
            product.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return Ok(response);
        }

        // DELETE: api/Product/"{id}"
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null || !product.IsActive)
                return NotFound(Message.ProductNotFound);

            product.IsActive = false;
            product.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok(new { Message = Message.ProductDeleted });
        }
    }
}