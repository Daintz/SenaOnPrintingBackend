using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class OrderProductionModel
    {
        public long IdOrderProduction { get; set; }
        public long? IdQuotationClient { get; set; }
        public long? IdUser { get; set; }
        public string? MaterialReception { get; set; }
        public long? IdProgram { get; set; }
        public string? ProgramVersion { get; set; }
        public double? Indented { get; set; }
        public string? ColorProfile { get; set; }
        public string? SpecialInk { get; set; }
        public string? InkCode { get; set; }
        public long? IdLineature { get; set; }
        public long? IdGrammage { get; set; }
        public long? IdPlateImposition { get; set; }
        public long? IdPaperCutSize { get; set; }
        public byte[]? Image { get; set; }
        public string? Observations { get; set; }
        public bool? StatedAt { get; set; } 
        public bool OrderStatus { get; set; } 

        public virtual GrammajeCaliberModel? IdGrammageNavigation { get; set; }
        public virtual LineatureModel? IdLineatureNavigation { get; set; }
        public virtual PaperCutModel? IdPaperCutSizeNavigation { get; set; }
        public virtual ImpositionPlateModel? IdPlateImpositionNavigation { get; set; }
        public virtual ProgramModel? IdProgramNavigation { get; set; }
        public virtual QuotationClientModel? IdQuotationClientNavigation { get; set; }
        public virtual UserModel? IdUserNavigation { get; set; }
    }
}
