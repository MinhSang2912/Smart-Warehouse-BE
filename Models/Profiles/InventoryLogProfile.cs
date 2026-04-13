using AutoMapper;
using Smart_Warehouse.Models.Entities.Inventories;
using Smart_Warehouse.Models.Requests.InventoryLog;
using Smart_Warehouse.Models.Respones.InventoryLog;
using static Smart_Warehouse.Common.Enums;

namespace Smart_Warehouse.Models.Profiles
{
    public class InventoryLogProfile : Profile
    {
        public InventoryLogProfile()
        {
            CreateMap<InventoryLog, InventoryLogResponse>();
            CreateMap<CreateInventoryLogRequest, InventoryLog>();
        }
    }
}
