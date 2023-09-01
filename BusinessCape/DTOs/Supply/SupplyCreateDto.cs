using DataCape.Models;

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
        public List<long> UnitMeasuresId { get; set; } = null!;
        public List<long> SupplyPictogramsId { get; set; } = null!;
        public List<long> SupplyCategoriesId { get; set; } = null!;
        public SupplyCreateDto()
        {
            StatedAt = true;
        }
    }
}

