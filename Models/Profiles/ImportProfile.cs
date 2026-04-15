using AutoMapper;
using Smart_Warehouse.Models.Entities.Order;
using Smart_Warehouse.Models.Requests.Import;
using Smart_Warehouse.Models.Respones.Import;

namespace Smart_Warehouse.Models.Profiles
{
    public class ImportProfile : Profile
    {
        public ImportProfile()
        {
            CreateMap<CreateImportRequest, Import>();
            CreateMap<UpdateImportRequest, Import>();
            CreateMap<Import, ImportResponse>()
                .ForMember(i => i.WarehouseName, opt => opt.MapFrom(src => src.Warehouse.Name))
                .ForMember(i => i.Details, opt => opt.MapFrom(src => src.Details))
                .ForMember(i => i.UserName, opt => opt.MapFrom(src => src.User.Username));
        }
    }
}
