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
<<<<<<< HEAD
        public bool QuotationStatus { get; set; }
        public bool? StatedAt { get; set; }

        public virtual ClientModel? Client { get; set; }
        public virtual TypeServiceModelModel? TypeService { get; set; }
        public virtual UserModelModel? User { get; set; }
        public virtual ICollection<QuotationClientDetail> QuotationClientDetails { get; set; }
=======
        public int? ProductQuantity { get; set; }
        public string? TechnicalSpecifications { get; set; }
        public int? InkQuantity { get; set; }
        public double? UnitValue { get; set; }
        public double? FullValue { get; set; }
        public double? ProductHigh { get; set; }
        public double? ProductWidth { get; set; }
        public int? NumberOfPages { get; set; }
        public bool? StatedAt { get; set; } = true;
        public bool QuotationStatus { get; set; } = true;

        public virtual ClientModel? IdClientNavigation { get; set; }
        public virtual FinishModel? IdFinishesNavigation { get; set; }
        public virtual MachineModel? IdMachineNavigation { get; set; }
        public virtual ProductModel? IdProductNavigation { get; set; }
        public virtual TypeServiceModel? IdTypeServiceNavigation { get; set; }
        public virtual UserModel? IdUserNavigation { get; set; }
        public virtual ICollection<OrderProductionModel>? OrderProductions { get; set; }
>>>>>>> 95dc0272dbf0fdf0da8f821efeeb82009668680d
    }
}
