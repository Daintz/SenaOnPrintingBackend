using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.Warehause
{
    public class WarehauseCreateDto
    {
        public long IdWarehouse { get; set; }
        public string Name { get; set; } = null!;
        public string Ubication { get; set; } = null!;
        public bool? StatedAt { get; set; }
        public long? IdTypeWarehouse { get; set; }

    }
}
