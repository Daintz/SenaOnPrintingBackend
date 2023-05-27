using System;
using System.Collections.Generic;

namespace DataCape
{
    public partial class LineatureXOrderProduction
    {
        public long? OrderProductionId { get; set; }
        public long? LineatureId { get; set; }

        public virtual Lineature? Lineature { get; set; }
        public virtual OrderProduction? OrderProduction { get; set; }
    }
}
