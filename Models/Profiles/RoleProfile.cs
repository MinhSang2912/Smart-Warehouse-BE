using AutoMapper;
using Smart_Warehouse.Models.Entities;
using Smart_Warehouse.Models.Respones.Role;

namespace Smart_Warehouse.Models.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleResponse>();
        }
    }
}
