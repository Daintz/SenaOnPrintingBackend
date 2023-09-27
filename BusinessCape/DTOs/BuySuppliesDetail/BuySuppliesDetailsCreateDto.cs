using DataCape.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessCape.DTOs.BuySuppliesDetail
{
    public class BuySuppliesDetailsCreateDto
    {
        public long? BuySuppliesId { get; set; }
        public long? SupplyId { get; set; }
        public decimal? SupplyCost { get; set; }
        public int? SupplyQuantity { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public long? WarehouseId { get; set; }
        public string? SecurityFile { get; set; }
        public IFormFile? SecurityFileInfo { get; set; } = null!;
        public bool? StatedAt { get; set; }
        public long? UnitMeasuresId { get; set; }
        public BuySuppliesDetailsCreateDto()
        {
            StatedAt = true;
        }
    }
}
