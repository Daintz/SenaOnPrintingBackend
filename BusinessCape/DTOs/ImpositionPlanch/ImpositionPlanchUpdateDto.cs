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
    };
    
}


