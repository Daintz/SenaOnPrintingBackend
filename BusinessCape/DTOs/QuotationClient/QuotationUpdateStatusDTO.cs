using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.QuotationClient
{
    public class QuotationUpdateStatusDTO
    {
        public long IdQuotationClient { get; set; }
        public bool? StatedAt { get; set; } = true;
    }
}
