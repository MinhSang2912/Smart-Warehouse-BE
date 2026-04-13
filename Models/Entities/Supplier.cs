namespace Smart_Warehouse.Models.Entities
{
    public class Supplier : BaseEntity
    {
        /// <summary>
        /// Tên nhà cung cấp
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Người liên hệ
        /// </summary>
        public string? ContactPerson { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Danh sách sản phẩm thuộc nhà cung cấp này
        /// </summary>
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}