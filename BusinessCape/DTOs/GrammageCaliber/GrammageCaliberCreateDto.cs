using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.GrammageCaliber
{
    public class GrammageCaliberCreateDto
    {


        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? StatedAt { get; set; }




    }
}
