using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public class QuotationClientModel
    {
        public QuotationClientModel()
        {
            QuotationClientDetails = new HashSet<QuotationClientDetailModel>();
        }

        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? ClientId { get; set; }
        public long? TypeServiceId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliverDate { get; set; }
        public bool QuotationStatus { get; set; }
        public bool? StatedAt { get; set; }

        public virtual ClientModel? Client { get; set; }
        public virtual TypeServiceModel? TypeService { get; set; }
        public virtual UserModel? User { get; set; }
        public virtual ICollection<QuotationClientDetailModel> QuotationClientDetails { get; set; }
    }
}
