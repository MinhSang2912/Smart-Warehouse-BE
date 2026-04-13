using AutoMapper;
using Smart_Warehouse.Models.Entities.Order;
using Smart_Warehouse.Models.Requests.ImportDetail;
using Smart_Warehouse.Models.Respones.ImportDetail;

namespace Smart_Warehouse.Models.Profiles
{
    public class ImportDetailProfile : Profile
    {
        public ImportDetailProfile()
        {
            CreateMap<ImportDetail, ImportDetailResponse>();
            CreateMap<CreateImportDetailRequest, ImportDetail>();
            CreateMap<UpdateImportDetailRequest, ImportDetail>();
        }
    }
}
