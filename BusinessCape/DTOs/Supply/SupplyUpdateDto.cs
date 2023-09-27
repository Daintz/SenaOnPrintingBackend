namespace BusinessCape.DTOs.Supply
{
    public class SupplyUpdateDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? DangerIndicators { get; set; }
        public string? UseInstructions { get; set; }
        public string? Advices { get; set; }
        public int SupplyType { get; set; }
        public int SortingWord { get; set; }
        public int? Quantity { get; set; }
        public decimal? AverageCost { get; set; }
        public DateTime ExpirationDate { get; set; }
        public long? WarehouseId { get; set; }
        public List<long> UnitMeasuresId { get; set; } = null!;
        public List<long> SupplyPictogramsId { get; set; } = null!;
        public List<long> SupplyCategoriesId { get; set; } = null!;
        //public long? supply_categories_id { get; set; }
        //public long? unit_measures_id { get; set; }
        //public long? supply_pictograms_id { get; set; }
    }
}


