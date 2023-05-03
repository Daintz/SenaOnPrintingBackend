using DataCape;
using PersistenceCape.Context;
using PersistenceCape.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Logic
{
    public class UserRepository : IUserRepository
    {
        private readonly SENAContext _context;

        public UserRepository(SENAContext context)
        {
            _context = context;
        }

        public IEnumerable<UserItem> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}
