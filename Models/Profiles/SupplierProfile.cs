using AutoMapper;
using Smart_Warehouse.Models.Entities;
using Smart_Warehouse.Models.Requests.Supplier;
using Smart_Warehouse.Models.Respones.Supplier;

namespace Smart_Warehouse.Models.Profiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierResponse>();
            CreateMap<CreateSupplierRequest, Supplier>();
            CreateMap<UpdateSupplierRequest, Supplier>();
        }

    }
}
