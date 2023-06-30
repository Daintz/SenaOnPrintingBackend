using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.TypeServices
{
    public class TypeServicesCreateDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? StatedAt { get; set; }
        public TypeServicesCreateDto()
        {
            StatedAt = true;
        }

    }
}
