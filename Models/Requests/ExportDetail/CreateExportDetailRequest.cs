namespace Smart_Warehouse.Models.Requests.ExportDetail
{
    public class CreateExportDetailRequest
    {
        /// <summary>
        /// Id sản phẩm
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Số lượng xuất
        /// </summary>
        public int Quantity { get; set; }
    }
}
