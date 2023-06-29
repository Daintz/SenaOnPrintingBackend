using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.TypeServices
{
    public class TypeServicesUpdateDto
    {
        public long IdTypeService { get; set; }
        public bool? StatedAt { get; set; }
        public string Name { get; set; } = null!;
        public decimal? Costo { get; set; }
    }
}
