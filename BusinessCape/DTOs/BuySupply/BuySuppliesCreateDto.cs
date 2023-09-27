using BusinessCape.DTOs.BuySuppliesDetail;
using BusinessCape.DTOs.QuotationClientDetail;
using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.BuySupply
{
    public class BuySuppliesCreateDto
    {

        public string? Description { get; set; }
        public long? ProviderId { get; set; }
        public DateTime? EntryDate { get; set; }
        public bool? StatedAt { get; set; }
        public BuySuppliesCreateDto()
        {
            StatedAt = true;
        }

        public List<BuySuppliesDetailsCreateDto> BuySuppliesDetails { get; set; }
    }
}
