using System;
using System.Collections.Generic;

namespace DataCape
{
    public partial class Finish
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? StatedAt { get; set; }
    }
}
