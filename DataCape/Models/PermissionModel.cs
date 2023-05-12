using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class PermissionModel
    {
        public Guid IdPermission { get; set; }
        public string Permission1 { get; set; } = null!;
        public long StatedAt { get; set; }
    }
}
