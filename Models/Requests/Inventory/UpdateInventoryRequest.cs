namespace Smart_Warehouse.Models.Requests.Inventory
{
    public class UpdateInventoryRequest
    {
        /// <summary>
        /// Id nhà kho
        /// </summary>
        public int? WarehouseId { get; set; }

        /// <summary>
        /// Id sản phẩm
        /// </summary>
        public Guid? ProductId { get; set; }

        /// <summary>
        /// Số lượng tồn kho hiện tại của sản phẩm trong nhà kho
        /// </summary>
        public int? Quantity { get; set; } = 0;

        /// <summary>
        /// Số lượng tối thiểu
        /// </summary>
        public int minQuantity { get; set; } = 0;
    }
}
