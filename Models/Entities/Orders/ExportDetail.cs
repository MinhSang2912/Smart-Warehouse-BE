namespace Smart_Warehouse.Models.Entities.Orders
{
    public class ExportDetail
    {
        public int Id { get; set; }
        /// <summary>
        /// Id phiếu xuất
        /// </summary>
        public int ExportId { get; set; }

        /// <summary>
        /// Khóa ngoại phiếu xuất (navigation property)
        /// </summary>
        public virtual Export Export{ get; set; } = null!;

        /// <summary>
        /// Id sản phẩm
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Khóa ngoại sản phẩm (navigation property)
        /// </summary>
        public virtual Product Product { get; set; } = null!;

        /// <summary>
        /// Số lượng xuất
        /// </summary>
        public int Quantity { get; set; }
    }
}
