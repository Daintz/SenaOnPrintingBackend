using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class UnitMeasuresXSupplyModel
    {
        public Guid IdUnitMeasure { get; set; }
        public Guid IdSupply { get; set; }

        public virtual SupplyModel IdSupplyNavigation { get; set; } = null!;
        public virtual UnitMeasureModel IdUnitMeasureNavigation { get; set; } = null!;
    }
}
