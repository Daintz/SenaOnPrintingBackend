using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataCape.Models
{
    public class QuotationClientDetailModel
    {
        public QuotationClientDetailModel()
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

        [NotMapped]
        public DateTime? OrderDate { get; set; }
        [NotMapped]
        public string Name { get; set; } = null!;
        [NotMapped]
        public string ProductName { get; set; } = null!;
        [NotMapped]
        public DateTime? DeliverDate { get; set; }
        [NotMapped]
        public string? PhoneClient { get; set; }
        [NotMapped]
        public string EmailClient { get; set; }
        [NotMapped]
        public string TypeService { get; set; }

        public virtual ProductModel? Product { get; set; }
        public virtual QuotationClientModel? QuotationClient { get; set; }
        public virtual ICollection<OrderProductionModel> OrderProductions { get; set; }
    }
}
