using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.Provider
{
    public class ProviderCreateDto
    {
        public long IdProvider { get; set; }
        public bool? StatedAt { get; set; }
        public string NameCompany { get; set; } = null!;
        public long NitCompany { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string CompanyAddress { get; set; } = null!;

    }
}
