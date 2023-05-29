using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.Client
{
    public class ClientCreateDto
    {
        public string Name { get; set; } = null!;
        public string? Phone { get; set; }
        public string Email { get; set; } = null!;
        public string Center { get; set; } = null!;
        public string Area { get; set; } = null!;
        public string Regional { get; set; } = null!;
        public bool? StatedAt { get; set; }

        //public virtual ICollection<QuotationClientModel> QuotationClients { get; set; }

    }
}
