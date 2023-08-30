using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public   class QuotationClientModel
    {
        public QuotationClientModel()
        {
            QuotationClientDetails = new List<QuotationClientDetailModel>();
        }

        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? ClientId { get; set; }
        public int Code { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliverDate { get; set; }
        public int? QuotationStatus { get; set; }
        public int? FullValue { get; set; }
        public bool? StatedAt { get; set; }

        public virtual ClientModel? Client { get; set; }
        public virtual UserModel? User { get; set; }
        public virtual List<QuotationClientDetailModel> QuotationClientDetails { get; set; }
    }
}
