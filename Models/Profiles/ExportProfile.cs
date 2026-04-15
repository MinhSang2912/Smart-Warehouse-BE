using AutoMapper;
using Smart_Warehouse.Models.Entities.Orders;
using Smart_Warehouse.Models.Requests.Export;
using Smart_Warehouse.Models.Respones.Export;

namespace Smart_Warehouse.Models.Profiles
{
    public class ExportProfile : Profile
    {
        public ExportProfile()
        {
            CreateMap<Export, ExportResponse>()
                .ForMember(e => e.WarehouseName, opt => opt.MapFrom(src => src.Warehouse.Name))
                .ForMember(e => e.UserName, opt => opt.MapFrom(src => src.User.Username))
                .ForMember(e => e.Details, opt => opt.MapFrom(src => src.Details));
            CreateMap<CreateExportRequest, Export>();
            CreateMap<UpdateExportRequest, Export>();
        }
    }
}
