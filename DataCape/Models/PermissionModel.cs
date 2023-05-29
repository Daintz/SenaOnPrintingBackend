using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class PermissionModel
    {
        public long IdPermission { get; set; }
        public string Permission1 { get; set; } = null!;
        public bool? StatedAt { get; set; }
    }
}
