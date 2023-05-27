using System;
using System.Collections.Generic;

namespace DataCape
{
    public partial class FinishXQuotationClientDetail
    {
        public long? QuotationClientDetailId { get; set; }
        public long? FinishId { get; set; }

        public virtual Finish? Finish { get; set; }
        public virtual QuotationClientDetail? QuotationClientDetail { get; set; }
    }
}
