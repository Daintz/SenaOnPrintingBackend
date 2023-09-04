using DataCape.Models;

namespace BusinessCape.DTOs.Product
{
    public class ProductCreateDto
    {
        public long Id { get; set; }
        public List<long> SupplyIds { get; set; }
        public string Name { get; set; } = null!;
        public string TypeProduct { get; set; } = null!;
        public long? PaperCutId { get; set; }
        public decimal? Cost { get; set; }
        public string? Observations { get; set; }
        public bool? StatedAt { get; set; }
        public string Size { get; set; } = null!;
        public bool? FrontPage { get; set; }
        public bool? FrontPageInks { get; set; }
        public string? FrontPagePantone { get; set; }
        public string? FrontPageCode { get; set; }
        public bool? BackCover { get; set; }
        public bool? BackCoverInks { get; set; }
        public string? BackCoverPantone { get; set; }
        public string? BackCoverCode { get; set; }
        public bool? Inside { get; set; }
        public bool? InsideInks { get; set; }
        public string? InsidePantone { get; set; }
        public string? InsideCode { get; set; }
        public long? NumberPages { get; set; }
        public string? Bindings { get; set; }
        public string? Dimension { get; set; }
        public string? SubstratumFrontPage { get; set; }
        public string? SubstratumBackCover { get; set; }
        public string? SubstratumInside { get; set; }
        public string? Substratum { get; set; }
    }
}
