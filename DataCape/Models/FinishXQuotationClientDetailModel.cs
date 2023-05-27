using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class FinishXQuotationClientDetail
    {
        public long? QuotationClientDetailId { get; set; }
        public long? FinishId { get; set; }

        public virtual FinishModel? Finish { get; set; }
        public virtual QuotationClientDetail? QuotationClientDetail { get; set; }
    }
}
