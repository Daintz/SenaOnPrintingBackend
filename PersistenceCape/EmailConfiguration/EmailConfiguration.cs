using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.EmailConfiguration
{
    public class EmailConfiguration
    {
        public String From { get; set; }

        public String Server { get; set; }

        public int Port { get; set; }

        public String EmailAddress { get; set; }

        public String EmailPassword { get; set; }
    }
}
