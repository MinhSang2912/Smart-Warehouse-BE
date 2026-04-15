namespace Smart_Warehouse.Models.Respones.ImportDetail
{
    public class ImportDetailResponse
    {
        public int Id { get; set; }
        public int ImportId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? ProductSKU { get; set; }
        public int Quantity { get; set; }
    }
}
