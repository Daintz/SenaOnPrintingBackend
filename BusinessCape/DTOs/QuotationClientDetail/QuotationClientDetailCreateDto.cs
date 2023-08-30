using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.QuotationClientDetail
{
    public class QuotationClientDetailCreateDto
    {
        public long? TypeServiceId { get; set; }
        public long? ProductId { get; set; }
        public int Cost { get; set; }
        public int? Quantity { get; set; }

        //public QuotationClientCreateDto()
        //{
        //    StatedAt = true;
        //}

    }
}
