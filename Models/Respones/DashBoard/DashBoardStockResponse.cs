namespace Smart_Warehouse.Models.Respones.DashBoard
{
    public class DashBoardStockResponse
    {
        /// <summary>
        /// Id sản phẩm
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        public string ProductName { get; set; } = "";

        /// <summary>
        /// Sku sản phẩm
        /// </summary>
        public string ProductSku { get; set; } = "";

        /// <summary>
        /// Số lượng sản phẩm
        /// </summary>
        public int CurrentStock { get; set; } = 0;
    }
}
