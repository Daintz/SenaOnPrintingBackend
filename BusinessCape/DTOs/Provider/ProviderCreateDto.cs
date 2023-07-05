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
        public string NameCompany { get; set; } = null!;
        public string NitCompany { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string? CompanyAddress { get; set; }
        public bool? StatedAt { get; set; }
        public ProviderCreateDto()
        {
            StatedAt = true;
        }

    }
}
