using System;
using System.Collections.Generic;

namespace DataCape
{
    public partial class QuotationClientModel
    {
        public QuotationClientModel()
        {
            QuotationClientDetails = new HashSet<QuotationClientDetail>();
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
        public virtual TypeServiceModelModel? TypeService { get; set; }
        public virtual UserModelModel? User { get; set; }
        public virtual ICollection<QuotationClientDetail> QuotationClientDetails { get; set; }
    }
}
