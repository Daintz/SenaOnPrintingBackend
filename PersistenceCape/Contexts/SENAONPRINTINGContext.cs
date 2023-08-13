using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataCape.Models
{
    public partial class SENAONPRINTINGContext : DbContext
    {
        public SENAONPRINTINGContext()
        {
        }

        public SENAONPRINTINGContext(DbContextOptions<SENAONPRINTINGContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProviderModel> Providers { get; set; } = null!;
        public virtual DbSet<SupplyModel> Supplies { get; set; } = null!;
        public virtual DbSet<SupplyDetailModel> SupplyDetails { get; set; } = null!;
        public virtual DbSet<TypeServiceModel> TypeServices { get; set; } = null!;
        public virtual DbSet<WarehouseModel> Warehouses { get; set; } = null!;

        public virtual DbSet<QuotationModel> Quotations { get; set; } = null!;

    }
      
}
