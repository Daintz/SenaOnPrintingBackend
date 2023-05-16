using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.WarehauseType
{
    internal class WarehauseTypeCreateDto
    {
        public long IdTypeWarehouse { get; set; }
        public bool? StatedAt { get; set; }
        public string? Nametype { get; set; }
        public string? Description { get; set; }

        public virtual WarehouseModel? Warehouse { get; set; }
    }
}
