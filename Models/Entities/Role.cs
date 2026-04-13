namespace Smart_Warehouse.Models.Entities
{
    public class Role : BaseEntity
    {
        /// <summary>
        /// Tên của vai trò
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Lấy danh sách người dùng có vai trò này
        /// </summary>
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
