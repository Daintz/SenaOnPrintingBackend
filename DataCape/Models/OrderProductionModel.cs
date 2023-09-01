using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataCape.Models
{
    public class OrderProductionModel
    {
        public long Id { get; set; }
        public long? QuotationClientDetailId { get; set; }
        public long? UserId { get; set; }
        public string? MaterialReception { get; set; }
        public string? Program { get; set; }
        public string? ProgramVersion { get; set; }
        public double? Indented { get; set; }
        public string? Lineature { get; set; }
        public string? ColorProfile { get; set; }
        public string? TypePoint { get; set; }
        public string? Observations { get; set; }
        public string? Image { get; set; }
        public string? Scheme { get; set; }
        public long? ImpositionPlanchId { get; set; }
        public long? MachineId { get; set; }
        public int? OrderStatus { get; set; }
        public bool StatedAt { get; set; }

        public virtual ImpositionPlanchModel? ImpositionPlanch { get; set; }
        public virtual MachineModel? Machine { get; set; }
        public virtual QuotationClientDetailModel? QuotationClientDetail { get; set; }
        public virtual UserModel? User { get; set; }
        [NotMapped]
        public DateTime? OrderDate { get; set; }
        [NotMapped]
        public string Name { get; set; } = null!;
        [NotMapped]
        public string Product { get; set; } = null!;
        [NotMapped]
        public DateTime? DeliverDate { get; set; }

    }
}
