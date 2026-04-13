namespace Smart_Warehouse.Models.Requests.ImportDetail
{
    public class CreateImportDetailRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
