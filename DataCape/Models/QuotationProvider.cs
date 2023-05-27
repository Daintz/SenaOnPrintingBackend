using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class QuotationProvider
    {
        public long IdQuotationProvider { get; set; }
        public DateTime? Date { get; set; }
        public byte[]? QuotationFile { get; set; }
        public double? FullValue { get; set; }
        public long? IdProvider { get; set; }
        public bool? StatedAt { get; set; }

        public virtual Provider? IdProviderNavigation { get; set; }
    }
}
