using DataCape.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using PersistenceCape.Interfaces;

namespace PersistenceCape.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SENAONPRINTINGContext _context;

        public UserRepository(SENAONPRINTINGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserModel>> Index()
        {
            return await _context.Users.Include(x => x.Role).Include(x => x.TypeDocument).ToListAsync();
        }

        public async Task<UserModel> Show(long id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task Update(UserModel user)
        {
            //user.PasswordDigest = encryptPassword(user.PasswordDigest);
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProfile(UserModel user)
        {
            //user.PasswordDigest = encryptPassword(user.PasswordDigest);
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<UserModel> Create(UserModel user)
        {
            //user.PasswordDigest = encryptPassword(user.PasswordDigest);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task Delete(long id)
        {
            var user = await _context.Users.FindAsync(id);
            user.StatedAt = !user.StatedAt;
            await _context.SaveChangesAsync();
        }
    }
}
