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
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? ClientId { get; set; }
        public long? TypeServiceId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliverDate { get; set; }
        public bool QuotationStatus { get; set; }
        public bool? StatedAt { get; set; }

    }
}
