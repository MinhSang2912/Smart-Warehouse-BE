namespace Smart_Warehouse.Models.Respones.DashBoard
{
    public class DashBoardImportExportResponse
    {
        /// <summary>
        /// Ngày 
        /// </summary>
        public int Day { get; set; } = 1;

        /// <summary>
        /// Số lượng nhập
        /// </summary>
        public long? ImportQuantity { get; set; } = 0;

        /// <summary>
        /// Số lượng xuất
        /// </summary>
        public long? ExportQuantity { get; set; } = 0;
    }
}
