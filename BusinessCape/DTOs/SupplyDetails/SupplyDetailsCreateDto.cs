using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using BusinessCape.DTOs.SupplySupplyDetails;
using System.ComponentModel.DataAnnotations;

namespace BusinessCape.DTOs.SupplyDetails
{
    public class SupplyDetailsCreateDto
    {
        [Required]
        public long ProviderId { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime EntryDate { get; set; }
        public List<SupplySupplyDetailsCreateDto> Supplies { get; set; }



    }
}
