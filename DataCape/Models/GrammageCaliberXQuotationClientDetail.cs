using System;
using System.Collections.Generic;

namespace DataCape
{
    public partial class GrammageCaliberXQuotationClientDetail
    {
        public long? OrderProductionId { get; set; }
        public long? GrammageCaliberId { get; set; }

        public virtual GrammageCaliber? GrammageCaliber { get; set; }
        public virtual QuotationClientDetail? OrderProduction { get; set; }
    }
}
