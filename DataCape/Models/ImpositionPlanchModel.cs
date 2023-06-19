using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataCape.Models
{
    public class ImpositionPlanchModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Scheme { get; set; }
        public bool? StatedAt { get; set; }
        [NotMapped]
        public string? ImageSrc { get; set; }

    }
}
