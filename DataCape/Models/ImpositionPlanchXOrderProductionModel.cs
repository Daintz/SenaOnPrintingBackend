﻿using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class ImpositionPlanchXOrderProductionModel
    {
        public long? OrderProductionId { get; set; }
        public long? ImpositionPlanchId { get; set; }

        public virtual ImpositionPlanchModel? ImpositionPlanch { get; set; }
        public virtual OrderProduction? OrderProduction { get; set; }
    }
}