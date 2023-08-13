using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCape.Models
{
    internal class PaperCutModel
    {
        public long Id { get; set; }

        //Relación de uno a uno con orden de producción
        public long OrderProductionId { get; set; }
        public virtual OrderProductionModel OrderProduction { get; set; }
    }
}
