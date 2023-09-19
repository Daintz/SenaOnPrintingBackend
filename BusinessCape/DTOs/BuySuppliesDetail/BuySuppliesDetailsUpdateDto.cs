using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.BuySuppliesDetail
{
    public class BuySuppliesDetailsUpdateDto
    {
        public long Id { get; set; }
        public long? BuySuppliesId { get; set; }
        public long? SupplyId { get; set; }
        public decimal? SupplyCost { get; set; }
        public int? SupplyQuantity { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public long? WarehouseId { get; set; }
        public string? SecurityFile { get; set; }
        public long? UnitMeasuresId { get; set; }
    }
}
