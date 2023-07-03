namespace BusinessCape.DTOs.Product
{
    public class ProductUpdateDto
    {
        public long Id { get; set; }
        public string TypeProduct { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Characteristics { get; set; }
        public decimal? Cost { get; set; }
    }
}
