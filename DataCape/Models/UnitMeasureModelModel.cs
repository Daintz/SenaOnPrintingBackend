using System;
using System.Collections.Generic;

namespace DataCape
{
    public partial class UnitMeasureModelModel
    {
        public UnitMeasureModelModel()
        {
            InverseBase = new HashSet<UnitMeasureModelModel>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Abbreviation { get; set; }
        public int Type { get; set; }
        public long? BaseId { get; set; }
        public decimal? ConversionFactor { get; set; }
        public bool? StatedAt { get; set; }

        public virtual UnitMeasureModelModel? Base { get; set; }
        public virtual ICollection<UnitMeasureModelModel> InverseBase { get; set; }
    }
}
