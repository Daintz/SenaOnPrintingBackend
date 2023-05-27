using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class UnitMeasuresXSupply
    {
        public long IdUnitMeasure { get; set; }
        public long IdSupply { get; set; }

        public virtual Supply IdSupplyNavigation { get; set; } = null!;
        public virtual UnitMeasure IdUnitMeasureNavigation { get; set; } = null!;
    }
}
