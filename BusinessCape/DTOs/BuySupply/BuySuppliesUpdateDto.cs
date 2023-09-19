using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.BuySupply
{
    public class BuySuppliesUpdateDto
    {
        public long Id { get; set; }
        public string? Description { get; set; }
        public long? ProviderId { get; set; }
        public DateTime? EntryDate { get; set; }
    }
}
