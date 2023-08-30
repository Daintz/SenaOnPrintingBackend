using BusinessCape.DTOs.QuotationClientDetail;
using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.QuotationClient
{
    public class QuotationClientCreateDto
    {
        public long? UserId { get; set; }
        public long? ClientId { get; set; }
        public int Code { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliverDate { get; set; }
        public int? QuotationStatus { get; set; }
        public int? FullValue { get; set; }
        public bool? StatedAt { get; set; }

        public QuotationClientCreateDto()
        {
            StatedAt = true;
        }

        public List<QuotationClientDetailCreateDto> quotationClientDetailCreateDto { get; set; }


    }
}
