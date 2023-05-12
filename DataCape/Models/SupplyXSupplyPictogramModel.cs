using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class SupplyXSupplyPictogramModel
    {
        public Guid IdSupply { get; set; }
        public Guid IdSupplyPictogram { get; set; }

        public virtual SupplyModel IdSupplyNavigation { get; set; } = null!;
        public virtual SupplyPictogramModel IdSupplyPictogramNavigation { get; set; } = null!;
    }
}
