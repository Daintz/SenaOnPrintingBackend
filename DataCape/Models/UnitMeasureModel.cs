using System;
using System.Collections.Generic;

namespace DataCape
{


    public class UnitMeasureModel

    {
        public UnitMeasureModel()
        {
            InverseBase = new HashSet<UnitMeasureModel>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Abbreviation { get; set; }
        public int Type { get; set; }
        public long? BaseId { get; set; }
        public decimal? ConversionFactor { get; set; }
        public bool? StatedAt { get; set; }

        public virtual UnitMeasureModel? Base { get; set; }
        public virtual ICollection<UnitMeasureModel> InverseBase { get; set; }
    }
}
