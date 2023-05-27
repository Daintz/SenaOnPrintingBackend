using System;
using System.Collections.Generic;

namespace DataCape
{
    public partial class UnitMeasuresXSupply
    {
        public long? SupplyId { get; set; }
        public long? UnitMeasureId { get; set; }

        public virtual Supply? Supply { get; set; }
        public virtual UnitMeasure? UnitMeasure { get; set; }
    }
}
