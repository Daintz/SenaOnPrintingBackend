using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.ImpositionPlanch
{
    public class ImpositionPlanchUpdateDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Scheme { get; set; } = null!;
        public IFormFile? SchemeInfo { get; set; } = null!;
        //public bool? StatedAt { get; set; }
    };
    
}


