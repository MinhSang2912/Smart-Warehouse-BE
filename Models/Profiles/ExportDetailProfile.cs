using AutoMapper;
using Smart_Warehouse.Models.Entities.Orders;
using Smart_Warehouse.Models.Requests.ExportDetail;
using Smart_Warehouse.Models.Respones.ExportDetail;

namespace Smart_Warehouse.Models.Profiles
{
    public class ExportDetailProfile : Profile
    {
        public ExportDetailProfile()
        {
            CreateMap<ExportDetail, ExportDetailResponse>();
            CreateMap<CreateExportDetailRequest, ExportDetail>();
            CreateMap<UpdateExportDetailRequest, ExportDetail>();
        }

    }
}
