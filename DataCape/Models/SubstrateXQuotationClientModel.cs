using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class SubstrateXQuotationClientModel
    {
        public long IdSubstrate { get; set; }
        public long IdQuotationClient { get; set; }

        public virtual QuotationClientModel IdQuotationClientNavigation { get; set; } = null!;
        public virtual SubstrateModel IdSubstrateNavigation { get; set; } = null!;
    }
}
