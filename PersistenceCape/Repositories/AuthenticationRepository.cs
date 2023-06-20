using DataCape.Models;
using Microsoft.AspNetCore.Http;
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

        public async Task<UserModel> Authenticate(string email, string password)
        {
            var user = await _context.Users.Where(us => us.Email == email).FirstOrDefaultAsync();
            if (user != null)
            {
                if (VerifyPassword(password, user))
                {
                    return user;
                }
            }
            return null;

        }
        /*public bool Authenticate(string email, string password)
        {
            UserModel user = _context.Users.Where(us => us.Email == email).FirstOrDefault();
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
        }*/

        public bool CloseSession(string token)
        {
            return true;
        }

        public async Task<UserModel> ForgotPassword(string email)
        {
            var user = await _context.Users.Where(us => us.Email == email).FirstOrDefaultAsync();
            if (user != null)
            {
                string token = Guid.NewGuid().ToString();
                user.ForgotPasswordToken = token;
                
                await _context.SaveChangesAsync();
            }

            return user;
        }

        public async Task<bool> RecoveryPassword(string email, string token, string password, string confirmPassword)
        {
            var user = await _context.Users.Where(us => us.Email == email).FirstOrDefaultAsync();
            if (user != null && user.ForgotPasswordToken != null)
            {
                if (token == user.ForgotPasswordToken)
                {
                    if (password == confirmPassword)
                    {
                        user.PasswordDigest = password;
                        user.ForgotPasswordToken = null;
                        await _context.SaveChangesAsync();

                        return true;

                    }

                }

            }
            return false;
        }

        private bool VerifyPassword(string password, UserModel user)
        {
            var passwordHasher = new PasswordHasher<UserModel>();

            var is_valid = passwordHasher.VerifyHashedPassword(user, user.PasswordDigest, password);

            return is_valid == PasswordVerificationResult.Success;
        }

        
    }
}
