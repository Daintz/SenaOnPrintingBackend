using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public class SubstrateXQuotationClientDetailModel
    {
        public long? QuotationClientDetailId { get; set; }
        public long? SubstrateId { get; set; }

        public virtual QuotationClientDetailModel? QuotationClientDetail { get; set; }
        public virtual SubstrateModel? Substrate { get; set; }
    }
}
