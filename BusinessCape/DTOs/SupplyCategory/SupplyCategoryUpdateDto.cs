namespace BusinessCape.DTOs.SupplyCategory
{
    public class SupplyCategoryUpdateDto
    {
        public Guid IdSupplyCategory { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
