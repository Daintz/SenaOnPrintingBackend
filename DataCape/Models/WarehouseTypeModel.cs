﻿using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class WarehouseTypeModel
    {
        public WarehouseTypeModel()
        {
            Warehouses = new HashSet<WarehouseModel>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool? StatedAt { get; set; }

        public virtual ICollection<WarehouseModel> Warehouses { get; set; }
    }
}