using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataCape.Models
{
    public class QuotationClientDetailModel
    {
        public QuotationClientDetailModel()

        {
            OrderProductions = new List<OrderProductionModel>();
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
        public virtual QuotationClientModel QuotationClient { get; set; }
        [JsonIgnore]
        public virtual ProductModel Product { get; set; }
        public virtual TypeServiceModel TypeServiceModel { get; set; }
        public virtual List<OrderProductionModel> OrderProductions { get; set; }
    }
}
