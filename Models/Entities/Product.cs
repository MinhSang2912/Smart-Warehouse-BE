namespace Smart_Warehouse.Models.Entities
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string SKU { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; } = "Cái";

        public int MinStock { get; set; } = 10;
        public int MaxStock { get; set; } = 500;

        public Guid CategoryId { get; set; }
        public Catagory Category { get; set; } = null!;

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

    }
}
