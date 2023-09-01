using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.QuotationClient
{
    public class QuotationClientUpdateDto
    {
        public long Id {get; set;}
       public DateTime? OrderDate { get; set; }
        public DateTime? DeliverDate { get; set; }
        public int? QuotationStatus { get; set; }
        public int? FullValue { get; set; }

    }
}
