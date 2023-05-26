using System;
using System.Collections.Generic;

namespace DataCape
{
    public partial class TypeDocumentModel
    {
        public TypeDocumentModel()
        {
            Users = new HashSet<UserModelModel>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Abbreviation { get; set; } = null!;
        public bool? StatedAt { get; set; }

        public virtual ICollection<UserModelModel> Users { get; set; }
    }
}
