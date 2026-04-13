namespace Smart_Warehouse.Models.Entities
{
    public class Category : BaseEntity
    {
        /// <summary>
        /// Tên danh mục
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Mô tả danh mục
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Danh sách sản phẩm
        /// </summary>
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
