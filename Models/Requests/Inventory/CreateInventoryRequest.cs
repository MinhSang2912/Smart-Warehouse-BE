namespace Smart_Warehouse.Models.Requests.Inventory
{
    public class CreateInventoryRequest
    {
        /// <summary>
        /// Id nhà kho
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// Id sản phẩm
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Số lượng tồn kho hiện tại của sản phẩm trong nhà kho
        /// </summary>
        public int Quantity { get; set; } = 0;
    }
}
