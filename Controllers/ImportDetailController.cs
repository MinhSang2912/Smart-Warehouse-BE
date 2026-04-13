using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_Warehouse.Common;
using Smart_Warehouse.Data;
using Smart_Warehouse.Models.Entities.Order;
using Smart_Warehouse.Models.Requests.Import;
using Smart_Warehouse.Models.Requests.ImportDetail;
using Smart_Warehouse.Models.Respones.ImportDetail;

namespace Smart_Warehouse.Controllers
{
    [ApiController]
    [Route("api/import-details")]
    public class ImportDetailController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public ImportDetailController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/import-details?importId=5
        //[HttpGet]
        //public async Task<ActionResult<List<ImportDetailResponse>>> GetImportDetails([FromQuery] int? importId)
        //{
        //    var query = _context.ImportDetails
        //        .Include(d => d.Product)
        //        .AsQueryable();

        //    if (importId.HasValue)
        //    {
        //        query = query.Where(d => d.ImportCode = importId.Value);
        //    }

        //    var details = await query.ToListAsync();

        //    var responses = _mapper.Map<List<ImportDetailResponse>>(details);
        //    return Ok(responses);
        //}

        // GET: api/import-details/"id"
        //[HttpGet("id")]
        //public async Task<ActionResult<ImportDetailResponse>> GetById(int id)
        //{
        //    var detail = await _context.ImportDetails
        //        .Include(d => d.Product)
        //        .FirstOrDefaultAsync(d => d.Id == id);

        //    if (detail == null)
        //        return NotFound(Message.ImportDetailNotFound);

        //    var response = _mapper.Map<ImportDetailResponse>(detail);
        //    return Ok(response);
        //}


        // POST: api/import-details
        //[HttpPost]
        //public async Task<ActionResult> Create([FromBody] CreateImportDetailRequest request)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    // Kiểm tra Import tồn tại
        //    if (!await _context.Imports.AnyAsync(i => i.Id == request.ImportId))
        //        return BadRequest(Message.ImportNotFound);

        //    // Kiểm tra Product tồn tại
        //    if (!await _context.Products.AnyAsync(p => p.Id == request.ProductId))
        //        return BadRequest(Message.ProductNotFound);

        //    // Kiểm tra Quantity
        //    if (request.Quantity <= 0)
        //        return BadRequest("Số lượng phải lớn hơn 0");

        //    var detail = _mapper.Map<ImportDetail>(request);

        //    _context.ImportDetails.Add(detail);
        //    await _context.SaveChangesAsync();

        //    var response = _mapper.Map<ImportDetail>(detail);

        //    return Ok(response);
        //}

        // PUT: api/import-details/"id"
        //[HttpPut("id")]
        //public async Task<ActionResult> Update(int id, [FromBody] UpdateImportDetailRequest request)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var detail = await _context.ImportDetails
        //        .Include(d => d.Product)
        //        .FirstOrDefaultAsync(d => d.Id == id);

        //    if (detail == null)
        //        return NotFound(Message.ImportDetailNotFound);

        //    if (request.Quantity <= 0)
        //        return BadRequest("Số lượng phải lớn hơn 0");

        //    _mapper.Map(request, detail);
        //    await _context.SaveChangesAsync();

        //    var response = _mapper.Map<ImportDetailResponse>(detail);

        //    return Ok(new
        //    {
        //        Message = Message.ImportDetailUpdated,
        //        Data = response
        //    });
        //}
    }
}