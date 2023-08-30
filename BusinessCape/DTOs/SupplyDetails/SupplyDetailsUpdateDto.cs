using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.SupplyDetails
{
    public class SupplyDetailsUpdateDto
    {
        public long Id { get; set; }
        public long? SupplyId { get; set; }
        public long? ProviderId { get; set; }
        public string? Description { get; set; }
        public decimal? SupplyCost { get; set; }
        public string? Batch { get; set; }
        public int InitialQuantity { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int? ActualQuantity { get; set; }
        public long? WarehouseId { get; set; }
        //public string? security_file { get; set; }
        //public Microsoft.AspNetCore.Http.IFormFile? security_fileInfo { get; set; } = null!;
        //public string? supplies_label { get; set; }
        //public Microsoft.AspNetCore.Http.IFormFile? supplies_labelInfo { get; set; } = null!;



    }
}
