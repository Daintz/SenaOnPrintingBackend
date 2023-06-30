using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.SupplyPictograms
{
    public class SupplyPictogramsCreateDto
    {
      
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? PictogramFile { get; set; }
        public Microsoft.AspNetCore.Http.IFormFile? PictogramFileInfo { get; set; } = null!;
        public bool? StatedAt { get; set; }
    }

}


