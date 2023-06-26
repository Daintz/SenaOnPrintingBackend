using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.PaperCut
{
    public class PaperCutCreateDto
    {

        public string Name { get; set; } = null!;
        public bool? StatedAt { get; set; }
        public PaperCutCreateDto()
        {
            StatedAt = true;
        }
        //public virtual ICollection<OrderProductionModel> OrderProductions { get; set; }
    }
}
