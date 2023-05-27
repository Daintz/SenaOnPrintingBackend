﻿using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.Lineature
{
    public class LineatureCreateDto
    {
        public long IdLineature { get; set; }

        public string? Lineature1 { get; set; } = null!;
        public string? TypePoint { get; set; } = null!;
        public string? Other { get; set; } = null!;
        public bool? StatedAt { get; set; }


    }
}
