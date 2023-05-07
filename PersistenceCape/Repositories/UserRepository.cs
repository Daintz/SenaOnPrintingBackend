using DataCape.Items;
using Microsoft.EntityFrameworkCore;
using PersistenceCape.Contexts;
using PersistenceCape.Interfaces;

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

        public UserItem GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public void Add(UserItem item)
        {
            _context.Users.Add(item);
            _context.SaveChanges();
        }

        public void Update(UserItem item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _context.Users.Find(id);
            _context.Users.Remove(item);
            _context.SaveChanges();
        }
    }
}
