namespace BusinessCape.DTOs.Supply
{
    public class SupplyCreateDto
    {
        public string Name { get; set; } = null!;
        public string? DangerIndicators { get; set; }
        public string? UseInstructions { get; set; }
        public string? Advices { get; set; }
        public int SupplyType { get; set; }
        public int SortingWord { get; set; }
        public int? Quantity { get; set; }
        public decimal? AverageCost { get; set; }

        public bool? StatedAt { get; set; }
        //public long? supply_categories_id { get; set; }
        //public long? unit_measures_id { get; set; }
        //public long? supply_pictograms_id { get; set; }
        public SupplyCreateDto()
        {
            StatedAt = true;
        }
    }
}

