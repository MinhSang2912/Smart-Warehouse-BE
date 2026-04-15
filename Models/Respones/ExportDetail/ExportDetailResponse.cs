namespace Smart_Warehouse.Models.Respones.ExportDetail
{
    public class ExportDetailResponse
    {
        public int Id { get; set; }
        /// <summary>
        /// Id phiếu xuất
        /// </summary>
        public int ExportId { get; set; }

        /// <summary>
        /// Id sản phẩm
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// SKU sản phẩm
        /// </summary>
        public string? ProductSKU { get; set; }
        /// <summary>
        /// Số lượng xuất
        /// </summary>
        public int Quantity { get; set; }
    }
}
