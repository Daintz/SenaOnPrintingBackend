using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class QuotationClientModel
    {
        public QuotationClientModel()
        {
            OrderProductions = new HashSet<OrderProductionModel>();
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

        public virtual ClientModel? IdClientNavigation { get; set; }
        public virtual FinishModel? IdFinishesNavigation { get; set; }
        public virtual MachineModel? IdMachineNavigation { get; set; }
        public virtual ProductModel? IdProductNavigation { get; set; }
        public virtual TypeServiceModel? IdTypeServiceNavigation { get; set; }
        public virtual UserModel? IdUserNavigation { get; set; }
        public virtual ICollection<OrderProductionModel> OrderProductions { get; set; }
    }
}
