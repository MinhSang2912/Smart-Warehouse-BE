using Smart_Warehouse.Models.Entities;

namespace Smart_Warehouse.Models.Requests.Category
{
    public class UpdateCategoryRequest 
    {
        /// <summary>
        /// Tên danh mục
        /// </summary>
        public string? Name { get; set; } = string.Empty;

        /// <summary>
        /// Mô tả danh mục
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Trạng thái
        /// </summary>
        public bool isActive { get; set; } = true;
    }
}
