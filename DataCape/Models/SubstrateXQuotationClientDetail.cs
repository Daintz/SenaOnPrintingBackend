using System;
using System.Collections.Generic;

namespace DataCape
{
    public partial class SubstrateXQuotationClientDetail
    {
        public long? QuotationClientDetailId { get; set; }
        public long? SubstrateId { get; set; }

        public virtual QuotationClientDetail? QuotationClientDetail { get; set; }
        public virtual Substrate? Substrate { get; set; }
    }
}
