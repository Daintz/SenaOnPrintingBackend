using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.Client
{
    public class ClientUpdateDto
    {
        public long IdClient { get; set; }
        public bool? StatedAt { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Center { get; set; }
        public string? Area { get; set; }
        public string? Regional { get; set; }
    }
}
