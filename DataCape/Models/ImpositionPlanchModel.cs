using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCape.Models
{
    internal class ImpositionPlanchModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long OrderProductionId { get; set; }
        public virtual OrderProductionModel OrderProduction { get; set; }
    }
}
