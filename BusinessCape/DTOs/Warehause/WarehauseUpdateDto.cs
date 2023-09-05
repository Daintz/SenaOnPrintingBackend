using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.Warehause
{
    public class WarehauseUpdateDto
    {
        public long Id { get; set; }
        public long TypeServiceId { get; set; }
        public string? Ubication { get; set; }


    }
}
