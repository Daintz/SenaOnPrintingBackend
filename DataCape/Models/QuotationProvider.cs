using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class QuotationProvider
    {
        public long Id { get; set; }
        public DateTime? QuotationDate { get; set; }
        public byte[]? QuotationFile { get; set; }
        public double? FullValue { get; set; }
        public long? ProviderId { get; set; }
        public bool? StatedAt { get; set; }

        public virtual Provider? Provider { get; set; }
    }
}
