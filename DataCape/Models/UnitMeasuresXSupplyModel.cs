using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public class UnitMeasuresXSupplyModel
    {
        public long? SupplyId { get; set; }
        public long? UnitMeasureId { get; set; }

        public virtual SupplyModel? Supply { get; set; }
        public virtual UnitMeasureModel? UnitMeasure { get; set; }
    }
}
