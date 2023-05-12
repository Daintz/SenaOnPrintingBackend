using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class RoleModel
    {
        public Guid IdRole { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool? StatedAt { get; set; }

        public virtual UserModel? User { get; set; }
    }
}
