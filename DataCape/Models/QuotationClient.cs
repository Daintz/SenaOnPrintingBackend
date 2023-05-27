using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class QuotationClient
    {
        public QuotationClient()
        {
            OrderProductions = new HashSet<OrderProduction>();
        }

        public long IdQuotationClient { get; set; }
        public long? IdUser { get; set; }
        public long? IdClient { get; set; }
        public long? IdMachine { get; set; }
        public long? IdTypeService { get; set; }
        public long? IdSubstrate { get; set; }
        public long? IdFinishes { get; set; }
        public long? IdProduct { get; set; }
        public DateTime? DateOrde { get; set; }
        public DateTime? DeliverDate { get; set; }
        public int? ProductQuantity { get; set; }
        public string? TechnicalSpecifications { get; set; }
        public int? InkQuantity { get; set; }
        public double? UnitValue { get; set; }
        public double? FullValue { get; set; }
        public double? ProductHigh { get; set; }
        public double? ProductWidth { get; set; }
        public int? NumberOfPages { get; set; }
        public bool? StatedAt { get; set; }
        public bool QuotationStatus { get; set; }

        public virtual Client? IdClientNavigation { get; set; }
        public virtual Finish? IdFinishesNavigation { get; set; }
        public virtual Machine? IdMachineNavigation { get; set; }
        public virtual Product? IdProductNavigation { get; set; }
        public virtual TypeService? IdTypeServiceNavigation { get; set; }
        public virtual User? IdUserNavigation { get; set; }
        public virtual ICollection<OrderProduction> OrderProductions { get; set; }
    }
}
