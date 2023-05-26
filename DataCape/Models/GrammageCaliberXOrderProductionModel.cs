using System;
using System.Collections.Generic;

namespace DataCape
{
    public partial class GrammageCaliberXOrderProductionModel
    {
        public long? OrderProductionId { get; set; }
        public long? GrammageCaliberId { get; set; }

        public virtual FinishModel? GrammageCaliber { get; set; }
        public virtual OrderProductionModel? OrderProduction { get; set; }
    }
}
