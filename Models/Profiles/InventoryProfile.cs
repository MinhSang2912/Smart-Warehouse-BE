using AutoMapper;
using Smart_Warehouse.Models.Entities.Inventories;
using Smart_Warehouse.Models.Requests.Inventory;
using Smart_Warehouse.Models.Respones.Inventory;

namespace Smart_Warehouse.Models.Profiles
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<Inventory, InventoryResponse>()
                .ForMember(i => i.WarehouseName, opt => opt.MapFrom(src => src.Warehouse.Name))
                .ForMember(i => i.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(i => i.ProductIsActive, opt => opt.MapFrom(src => src.Product.IsActive))
                .ForMember(i => i.WarehouseIsActive, opt => opt.MapFrom(src => src.Warehouse.IsActive))
                .ForMember(i => i.minQuantity, opt => opt.MapFrom(src => src.Product.MinThreshold));


            CreateMap<CreateInventoryRequest, Inventory>();
            CreateMap<UpdateInventoryRequest, Inventory>();
        }
    }
}
