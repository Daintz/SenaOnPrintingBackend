using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.Finish
{
    public class FinishDtoCreate
    {

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? StatedAt { get; set; }

        public FinishDtoCreate()
        {
            StatedAt = true;
        }

    }
}