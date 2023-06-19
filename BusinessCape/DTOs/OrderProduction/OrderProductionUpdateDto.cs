using DataCape.Models;


namespace BusinessCape.DTOs.OrderProduction
{
    public class OrderProductionUpdateDto
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
        public long? IdPaperCut { get; set; }
        public string? Image { get; set; }
        public string? Observations { get; set; }
        public bool? StatedAt { get; set; }
        public bool OrderStatus { get; set; }
        public string? Program { get; set; }



    }
}
