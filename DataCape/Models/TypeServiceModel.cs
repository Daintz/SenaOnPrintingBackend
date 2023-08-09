﻿using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public class TypeServiceModel
    {
        public TypeServiceModel()
        {
            QuotationClients = new HashSet<QuotationClientModel>();
            Warehouses = new HashSet<WarehouseModel>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? StatedAt { get; set; }

        public virtual ICollection<QuotationClientModel> QuotationClients { get; set; }
        public virtual ICollection<WarehouseModel> Warehouses { get; set; }
    }
}
