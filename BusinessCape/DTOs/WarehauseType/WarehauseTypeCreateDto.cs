using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.WarehauseType
{
    public class WarehauseTypeCreateDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool? StatedAt { get; set; }


        public WarehauseTypeCreateDto()
        {
            StatedAt = true;
        }


    }
}
