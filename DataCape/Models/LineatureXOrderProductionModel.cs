using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public class LineatureXOrderProductionModel
    {
        public long? OrderProductionId { get; set; }
        public long? LineatureId { get; set; }

        public virtual LineatureModel? Lineature { get; set; }
        public virtual OrderProductionModel? OrderProduction { get; set; }
    }
}
