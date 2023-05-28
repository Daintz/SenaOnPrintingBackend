using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public class SupplyXSupplyPictogramModel
    {
        public long? SupplyId { get; set; }
        public long? SupplyPictogramId { get; set; }

        public virtual SupplyModel? Supply { get; set; }
        public virtual SupplyPictogramModel? SupplyPictogram { get; set; }
    }
}
