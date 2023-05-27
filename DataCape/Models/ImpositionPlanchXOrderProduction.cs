using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class ImpositionPlanchXOrderProduction
    {
        public long? OrderProductionId { get; set; }
        public long? ImpositionPlanchId { get; set; }

        public virtual ImpositionPlanch? ImpositionPlanch { get; set; }
        public virtual OrderProduction? OrderProduction { get; set; }
    }
}
