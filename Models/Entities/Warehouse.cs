using Smart_Warehouse.Models.Entities.Inventories;

namespace Smart_Warehouse.Models.Entities
{
    public class Warehouse : BaseEntity
    {
        /// <summary>
        /// Tên nhà kho
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Địa chỉ nhà kho
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string? Description { get; set; }


        /// <summary>
        /// Số lượng tối đa có thể lưu trữ của sản phẩm 
        /// </summary>
        public int MaxStock { get; set; }

        /// <summary>
        /// Danh sách tồn kho (Navigation Property)
        /// </summary>
        public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
    }
}
