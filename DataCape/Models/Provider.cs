﻿using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class Provider
    {
        public Provider()
        {
            QuotationProviders = new HashSet<QuotationProvider>();
            SupplyDetails = new HashSet<SupplyDetail>();
        }

        public long IdProvider { get; set; }
        public bool? StatedAt { get; set; }
        public string NameCompany { get; set; } = null!;
        public Guid NitCompany { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string CompanyAddress { get; set; } = null!;

        public virtual ICollection<QuotationProvider> QuotationProviders { get; set; }
        public virtual ICollection<SupplyDetail> SupplyDetails { get; set; }
    }
}
