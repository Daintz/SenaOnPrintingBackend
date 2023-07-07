using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public class SupplyModel
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

        public bool? StatedAt { get; set; }
        //public long? UnitMeasuresId { get; set; }
        //public long? SupplyPictogramsId { get; set; }
        //public long? SupplyCategoriesId { get; set; }

        //public virtual SupplyCategoryModel? SupplyCategories { get; set; }
        //public virtual SupplyPictogramModel? SupplyPictograms { get; set; }
        //public virtual UnitMeasureModel? UnitMeasures { get; set; }

        public virtual ICollection<SupplyDetailModel> SupplyDetails { get; set; }
    }
}
