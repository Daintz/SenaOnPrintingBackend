using System;
using System.Collections.Generic;

namespace DataCape
{
    public class ImpositionPlanchXOrderProductionModel
    {
        public long? OrderProductionId { get; set; }
        public long? ImpositionPlanchId { get; set; }

        public virtual ImpositionPlanchModel? ImpositionPlanch { get; set; }
        public virtual OrderProductionModel? OrderProduction { get; set; }
    }
}
