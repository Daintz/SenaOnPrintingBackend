namespace BusinessCape.DTOs.SupplyCategory
{
    public class SupplyCategoryCreateDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool? StatedAt { get; set; }

        public SupplyCategoryCreateDto()
        {
            StatedAt = true;
        }
    }
}
