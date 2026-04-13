using AutoMapper;
using Smart_Warehouse.Models.Entities;
using Smart_Warehouse.Models.Requests.Category;
using Smart_Warehouse.Models.Respones.Category;

namespace Smart_Warehouse.Models.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryResponse>();
            CreateMap<CreateCategoryRequest, Category>();
            CreateMap<UpdateCategoryRequest, Category>();
        }
    }
}
