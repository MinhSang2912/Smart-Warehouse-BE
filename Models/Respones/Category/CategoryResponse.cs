using Smart_Warehouse.Models.Entities;

namespace Smart_Warehouse.Models.Respones.Category
{
    public class CategoryResponse : BaseEntity
    {
        /// <summary>
        /// Tên danh mục
        /// </summary>
        
        public string? Name { get; set; } = string.Empty;

        /// <summary>
        /// Mô tả danh mục
        /// </summary>
        public string? Description { get; set; }
    }
}
