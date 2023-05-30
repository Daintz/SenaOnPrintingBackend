using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.QuotationProviders
{
    public class QuotationProvidersCreateDto
    {
        public long IdQuotationProvider { get; set; }
        public DateTime? Date { get; set; }
        public byte[]? QuotationFile { get; set; }
        public double? FullValue { get; set; }
        public long? IdProvider { get; set; }
        public bool? StatedAt { get; set; }
    }
}
