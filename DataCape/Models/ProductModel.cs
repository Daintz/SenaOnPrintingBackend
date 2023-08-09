namespace DataCape.Models
{
    public class ProductModel
    {
        public long Id { get; set; }
        public string TypeProduct { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Characteristics { get; set; }
        public bool? StatedAt { get; set; }
        public decimal? Cost { get; set; }
    }
}
