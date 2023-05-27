using System;
using System.Collections.Generic;

namespace DataCape
{
    public  class SupplyModel
    {
        public SupplyModel()
        {
            SupplyDetails = new HashSet<SupplyDetailModel>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? DangerIndicators { get; set; }
        public string? UseInstructions { get; set; }
        public string? Advices { get; set; }
        public int SupplyType { get; set; }
        public int SortingWord { get; set; }
        public int? Quantity { get; set; }
        public decimal? AverageCost { get; set; }
        public long? WarehouseId { get; set; }
        public bool? StatedAt { get; set; }

        public virtual WarehouseModel? Warehouse { get; set; }
        public virtual ICollection<SupplyDetailModel> SupplyDetails { get; set; }
    }
}
