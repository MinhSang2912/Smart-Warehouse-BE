namespace Smart_Warehouse.Models.Requests.ExportDetail
{
    public class UpdateExportDetailRequest
    {
        /// <summary>
        /// Id phiếu xuất
        /// </summary>
        public int ExportId { get; set; }

        /// <summary>
        /// Id sản phẩm
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Số lượng xuất
        /// </summary>
        public int Quantity { get; set; }
    }
}
