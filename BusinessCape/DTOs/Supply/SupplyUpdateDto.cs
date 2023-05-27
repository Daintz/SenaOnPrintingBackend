namespace BusinessCape.DTOs.Supply
{
    public class SupplyUpdateDto
    {
        public long IdSupply { get; set; }
        public string Name { get; set; } = null!;
        public long IdUnitMeasure { get; set; }
        public string? DangerIndicators { get; set; }
        public string? UseInstructions { get; set; }
        public string? Advices { get; set; }
        public int SupplyType { get; set; }
        public int SortingWord { get; set; }
        public int Quantity { get; set; }
        public decimal? AverageCost { get; set; }
        public long IdWarehouse { get; set; }
        public bool? StatedAt { get; set; }
    }
}
