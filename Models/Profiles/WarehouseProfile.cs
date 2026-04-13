using AutoMapper;
using Smart_Warehouse.Models.Entities;
using Smart_Warehouse.Models.Requests.Warehouse;
using Smart_Warehouse.Models.Respones.Warehouse;

namespace Smart_Warehouse.Models.Profiles
{
    public class WarehouseProfile : Profile
    {
        public WarehouseProfile()
        {
            CreateMap<Warehouse, WarehouseResponse>();
            CreateMap<CreateWarehouseRequest, Warehouse>();
            CreateMap<UpdateWarehouseRequest, Warehouse>();
        }
    }
}
