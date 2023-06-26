using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.Lineature
{
    public class LineatureCreateDto
    {
        public string? Lineature { get; set; } = null!;
        public bool? StatedAt { get; set; }


    }
}
