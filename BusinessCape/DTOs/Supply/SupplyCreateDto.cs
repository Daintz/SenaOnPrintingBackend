using DataCape.Models;

namespace BusinessCape.DTOs.Supply
{
    public class SupplyCreateDto
    {
        public Guid IdSupply { get; set; }
        public string Name { get; set; } = null!;
        public Guid MinimunUnitMeasureId { get; set; }
        public string? DangerIndicators { get; set; }
        public string? UseInstructions { get; set; }
        public string? Advices { get; set; }
        public int SupplyType { get; set; }
        public int SortingWord { get; set; }
        public int Quantity { get; set; }
        public decimal? AverageCost { get; set; }
        public bool? StatedAt { get; set; }
        public Guid IdWarehouse { get; set; }

        public virtual WarehouseModel IdWarehouseNavigation { get; set; } = null!;
    }
}
