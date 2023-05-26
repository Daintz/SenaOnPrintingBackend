using System;
using System.Collections.Generic;

namespace DataCape
{
    public partial class QuotationClientDetail
    {
        public QuotationClientDetail()
        {
            OrderProductions = new HashSet<OrderProductionModel>();
        }

        public long Id { get; set; }
        public long? QuotationClientId { get; set; }
        public long? ProductId { get; set; }
        public string? TechnicalSpecifications { get; set; }
        public double? ProductHeight { get; set; }
        public double? ProductWidth { get; set; }
        public int? NumberOfPages { get; set; }
        public int? InkQuantity { get; set; }
        public int? ProductQuantity { get; set; }
        public double? UnitValue { get; set; }
        public double? FullValue { get; set; }
        public bool? StatedAt { get; set; }

        public virtual ProductModel? Product { get; set; }
        public virtual QuotationClientModel? QuotationClient { get; set; }
        public virtual ICollection<OrderProductionModel> OrderProductions { get; set; }
    }
}
