using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace BusinessCape.DTOs.SupplyDetails
{
    public class SupplyDetailsCreateDto
    {
        public long ProviderId { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public bool StatedAt { get; set; }
        //public string? security_file { get; set; }
        //public Microsoft.AspNetCore.Http.IFormFile? security_fileInfo { get; set; } = null!;
        public float? FullValue { get; set; }

        public List<long> SupplyId { get; set; } = null!;
        public SupplyDetailsCreateDto()
        {
            StatedAt = true;
        }
        


    }
}
