using DataCape.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Seed
{
    public class Seeder
    {
        private readonly SENAONPRINTINGContext _context;

        public Seeder(SENAONPRINTINGContext context)
        {
            _context = context;
        }

        public void Seed() { 
        }
    }
}
