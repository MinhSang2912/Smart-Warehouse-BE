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
            CreateMap<Export, ExportResponse>();
            CreateMap<CreateExportRequest, Export>();
            CreateMap<UpdateExportRequest, Export>();
        }
    }
}
