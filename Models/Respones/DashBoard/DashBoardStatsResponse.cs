namespace Smart_Warehouse.Models.Respones.DashBoard
{
    public class DashBoardStatsResponse
    {
        /// <summary>
        /// Số lượng phiếu của hôm nay
        /// </summary>
        public int TotalTodayReceipts { get; set; }

        /// <summary>
        /// Số lượng phiếu của hôm qua
        /// </summary>
        public int TotalYesterdayReceipt { get; set; }
        
        /// <summary>
        /// Số lượng phiếu nhập hôm nay
        /// </summary>
        public int TodayImportReceipt{ get; set; }

        /// <summary>
        /// Số lượng phiếu xuất hôm nay
        /// </summary>
        public int TodayExportReceipt { get; set; }

        /// <summary>
        /// Số lượng kho sắp hết hàng
        /// </summary>
        public int TotalLowStock {  get; set; }
    }
}
