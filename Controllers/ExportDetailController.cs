using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_Warehouse.Common;
using Smart_Warehouse.Data;
using Smart_Warehouse.Models.Entities.Orders;
using Smart_Warehouse.Models.Requests.ExportDetail;
using Smart_Warehouse.Models.Respones.ExportDetail;

namespace Smart_Warehouse.Controllers
{
    [ApiController]
    [Route("api/export-details")]
    public class ExportDetailController : ControllerBase
    {
        readonly DatabaseContext _context;
        readonly IMapper _mapper;

        public ExportDetailController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //[HttpGet]
        //public async Task<ActionResult<List<ExportDetailResponse>>> GetAllExportDetails()
        //{
        //    var exportDetails = await _context.ExportDetails.ToListAsync();
        //    var response = _mapper.Map<List<ExportDetailResponse>>(exportDetails);

        //    return Ok(response);
        //}

        //[HttpPost]
        //public async Task<ActionResult> CreateExportDetail([FromBody] CreateExportDetailRequest request)
        //{
        //    var export = await _context.Exports.FindAsync(request.ExportId);
        //    if (export == null)
        //    {
        //        return NotFound(Message.ExportNotFound);
        //    }
        //    var response = _mapper.Map<ExportDetail>(request);

        //    _context.ExportDetails.Add(response);
        //    await _context.SaveChangesAsync();
        //    return Ok(response);
        //}
    }
}
