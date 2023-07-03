using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.Substrate
{
    public class SubstrateUpdateDto
    {

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal? Cost { get; set; }

    }
}
