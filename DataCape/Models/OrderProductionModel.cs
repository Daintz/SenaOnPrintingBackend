using System;
using System.Collections.Generic;

namespace DataCape
{
    public partial class OrderProductionModel
    {
        public long Id { get; set; }
        public long? QuotationClientDetailId { get; set; }
        public long? UserId { get; set; }
        public string? MaterialReception { get; set; }
        public string? ProgramVersion { get; set; }
        public double? Indented { get; set; }
        public string? ColorProfile { get; set; }
        public string? SpecialInk { get; set; }
        public string? InkCode { get; set; }
        public long? PaperCutId { get; set; }
        public byte[]? Image { get; set; }
        public string? Observations { get; set; }
        public bool StatedAt { get; set; }
        public bool OrderStatus { get; set; }
        public string? Program { get; set; }

        public virtual PaperCutModel? PaperCut { get; set; }
        public virtual QuotationClientDetail? QuotationClientDetail { get; set; }
        public virtual UserModelModel? User { get; set; }
    }
}
