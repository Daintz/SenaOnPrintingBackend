using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.Finish
{
    public class FinishDtoCreate
    {

        public long IdFinish { get; set; }
        public bool? StatedAt { get; set; }
        public string? FinishName { get; set; }

    }
}
