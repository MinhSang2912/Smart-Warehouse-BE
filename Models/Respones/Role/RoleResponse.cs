using Smart_Warehouse.Models.Entities;
using Smart_Warehouse.Models.Respones.User;

namespace Smart_Warehouse.Models.Respones.Role
{
    public class RoleResponse : BaseEntity
    {
        /// <summary>
        /// Tên của vai trò
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Lấy danh sách người dùng có vai trò này
        /// </summary>
        public virtual ICollection<UserResponse> Users { get; set; } = new List<UserResponse>();
    }
}
