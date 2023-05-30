namespace BusinessCape.DTOs.Product
{
    public class ProductCreateDto
    {
        public string TypeProduct { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Characteristics { get; set; }
    }
}
