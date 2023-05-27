using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.QuotationClient
{
    public class QuotationUpdateDto
    {
        public long IdQuotationClient { get; set; }
        public long? IdUser { get; set; }
        public long? IdClient { get; set; }
        public long? IdMachine { get; set; }
        public long? IdTypeService { get; set; }
        public long? IdSubstrate { get; set; }
        public long? IdFinishes { get; set; }
        public long? IdProduct { get; set; }
        public DateTime? DateOrde { get; set; }
        public DateTime? DeliverDate { get; set; }
        public int? ProductQuantity { get; set; }
        public string? TechnicalSpecifications { get; set; }
        public int? InkQuantity { get; set; }
        public double? UnitValue { get; set; }
        public double? FullValue { get; set; }
        public double? ProductHigh { get; set; }
        public double? ProductWidth { get; set; }
        public int? NumberOfPages { get; set; }
        public bool? StatedAt { get; set; } = true;
        public bool QuotationStatus { get; set; } = true;

        
    }
}
