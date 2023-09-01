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
        public long? TypeServiceId { get; set; }
        public long? ProductId { get; set; }
        public int Cost { get; set; }
        public int? Quantity { get; set; }
        public bool? StatedAt { get; set; }
        [NotMapped]
        public DateTime? OrderDate { get; set; }

        [NotMapped]
        public string ProductName { get; set; } = null!;
        [NotMapped]
        public string TypeServiceName { get; set; } = null!;
        [NotMapped]
        public DateTime? DeliverDate { get; set; }
        [NotMapped]
        public string Name { get; set; } = null!;
        public virtual ProductModel? Product { get; set; }
        public virtual QuotationClientModel QuotationClient { get; set; }
        public virtual TypeServiceModel? TypeService { get; set; }
        public virtual ICollection<OrderProductionModel> OrderProductions { get; set; }
    }
}
