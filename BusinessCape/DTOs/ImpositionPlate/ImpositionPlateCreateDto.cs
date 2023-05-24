using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.ImpositionPlate
{
    public class ImpositionPlateCreateDto
    {
        public long IdImpositionPlate { get; set; }

        public string ImpositionPlateName { get; set; } = null!;
        public byte[] Scheme { get; set; } = null!;
        public bool? StatedAt { get; set; }
    }
}
