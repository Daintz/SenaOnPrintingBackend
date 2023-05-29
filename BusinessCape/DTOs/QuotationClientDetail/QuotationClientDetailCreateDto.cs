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
        public long? QuotationClientId { get; set; }
        public long? ProductId { get; set; }
        public string? TechnicalSpecifications { get; set; }
        public double? ProductHeight { get; set; }
        public double? ProductWidth { get; set; }
        public int? NumberOfPages { get; set; }
        public int? InkQuantity { get; set; }
        public int? ProductQuantity { get; set; }
        public double? UnitValue { get; set; }
        public double? FullValue { get; set; }
        public bool? StatedAt { get; set; }

    }
}
