using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class SubstrateXQuotationClient
    {
        public long IdSubstrate { get; set; }
        public long IdQuotationClient { get; set; }

        public virtual QuotationClient IdQuotationClientNavigation { get; set; } = null!;
        public virtual Substrate IdSubstrateNavigation { get; set; } = null!;
    }
}
