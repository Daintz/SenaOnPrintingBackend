using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public class TypeDocumentModel
    {
        public TypeDocumentModel()
        {
            Users = new HashSet<UserModel>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Abbreviation { get; set; } = null!;
        public bool? StatedAt { get; set; }

        public virtual ICollection<UserModel> Users { get; set; }
    }
}
