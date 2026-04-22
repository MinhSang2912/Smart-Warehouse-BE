using AutoMapper;
using Smart_Warehouse.Models.Entities;
using Smart_Warehouse.Models.Respones.User;
using Smart_Warehouse.Models.Requests.User;

namespace Smart_Warehouse.Models.Profiles

{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserResponse>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name));
            CreateMap<CreateUserRequest, User>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());
            CreateMap<UpdateUserRequest, User>();
        }
    }
}
