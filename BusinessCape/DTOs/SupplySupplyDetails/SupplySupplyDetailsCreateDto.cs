using DataCape.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.SupplySupplyDetails
{
    public class SupplySupplyDetailsCreateDto
    {
        [Required]
        public long SupplyId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float SupplyCost { get; set; }
    }
}
