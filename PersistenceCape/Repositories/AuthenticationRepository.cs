using DataCape.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersistenceCape.Contexts;
using PersistenceCape.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly SENAONPRINTINGContext _context;
        public AuthenticationRepository(SENAONPRINTINGContext context) {
            _context = context;
        }

        public bool Authenticate(string email, string password)
        {
            User user = _context.Users.Where(us => us.Email == email).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            else
            {
                if (VerifyPassword(password, user))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool CloseSession(string token)
        {
            return true;
        }

        private bool VerifyPassword(string password, User user)
        {
            var passwordHasher = new PasswordHasher<User>();

            var is_valid = passwordHasher.VerifyHashedPassword(user, user.PasswordDigest, password);

            return is_valid == PasswordVerificationResult.Success;
        }
    }
}
