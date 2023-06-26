using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public class QuotationProviderModel
    {
        public long Id { get; set; }
        public DateTime? QuotationDate { get; set; }
        public string? QuotationFile { get; set; }
        public double? FullValue { get; set; }
        public long? ProviderId { get; set; }
        public bool? StatedAt { get; set; }

        public virtual ProviderModel? Provider { get; set; }
    }
}
