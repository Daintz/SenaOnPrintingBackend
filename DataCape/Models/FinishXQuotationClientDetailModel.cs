using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class FinishXQuotationClientDetailModel
    {
        public long? QuotationClientDetailId { get; set; }
        public long? FinishId { get; set; }

        public virtual FinishModel? Finish { get; set; }
        public virtual QuotationClientDetailModel? QuotationClientDetail { get; set; }
    }
}
