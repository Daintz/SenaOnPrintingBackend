namespace BusinessCape.DTOs.Product
{
    public class ProductCreateDto
    {
        public long Id { get; set; }
        public string TypeProduct { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Characteristics { get; set; }
        public decimal? Cost { get; set; }

        public bool? StatedAt { get; set; }
        public ProductCreateDto()
        {
            StatedAt = true;
        }
    }
}
