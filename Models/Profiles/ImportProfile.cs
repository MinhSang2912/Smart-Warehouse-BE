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
            CreateMap<Import, ImportResponse>();
        }
    }
}
