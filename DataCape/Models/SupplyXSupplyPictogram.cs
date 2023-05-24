using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class SupplyXSupplyPictogram
    {
        public long IdSupply { get; set; }
        public long IdSupplyPictogram { get; set; }

        public virtual Supply IdSupplyNavigation { get; set; } = null!;
        public virtual SupplyPictogram IdSupplyPictogramNavigation { get; set; } = null!;
    }
}
