using System;
using System.Collections.Generic;

namespace DataCape
{
    public partial class TypeDocument
    {
        public TypeDocument()
        {
            Users = new HashSet<User>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Abbreviation { get; set; } = null!;
        public bool? StatedAt { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
