using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace BusinessCape.DTOs.QuotationProviders
{
    public class QuotationProvidersCreateDto
    {
        
        public DateTime? QuotationDate { get; set; }
        public string? QuotationFile { get; set; }
        public Microsoft.AspNetCore.Http.IFormFile? QuotationFileInfo { get; set; } = null!;
        public double? FullValue { get; set; }
        public long? ProviderId { get; set; }
        public bool? StatedAt { get; set; }
    }
}


