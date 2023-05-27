using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class SupplyXSupplyPictogram
    {
        public long? SupplyId { get; set; }
        public long? SupplyPictogramId { get; set; }

        public virtual Supply? Supply { get; set; }
        public virtual SupplyPictogram? SupplyPictogram { get; set; }
    }
}
