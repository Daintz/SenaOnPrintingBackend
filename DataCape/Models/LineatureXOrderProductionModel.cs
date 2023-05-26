using System;
using System.Collections.Generic;

namespace DataCape
{
    public partial class LineatureXOrderProductionModel
    {
        public long? OrderProductionId { get; set; }
        public long? LineatureId { get; set; }

        public virtual LineatureModel? Lineature { get; set; }
        public virtual OrderProductionModel? OrderProduction { get; set; }
    }
}
