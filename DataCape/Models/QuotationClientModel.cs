using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCape.Models
{
    public class QuotationModel
    {
        public QuotationModel()
        {
            this.Products = new HashSet<ProductModel>();
            this.Machines = new HashSet<MachineModel>();
        }
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? ClientId { get; set; }
        public long? TypeServiceId { get; set; }
        public long? MachineId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliverDate { get; set; }
        public int? QuotationStatus { get; set; }
        public bool? StatedAt { get; set; }


        public virtual ClientModel? Client { get; set; }
        public virtual TypeServiceModel? TypeService { get; set; }
        public virtual UserModel? User { get; set; }

        public virtual ICollection<ProductModel> Products { get; set; }
        public virtual ICollection<MachinesModel> Machines { get; set; }
    }
}
