using AutoMapper;
using Smart_Warehouse.Models.Entities;
using Smart_Warehouse.Models.Requests.Product;
using Smart_Warehouse.Models.Respones.Product;

namespace Smart_Warehouse.Models.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product,ProductResponse>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.Name));
            CreateMap<CreateProductRequest,Product>();
            CreateMap<UpdateProductRequest,Product>();
        }
    }
}
