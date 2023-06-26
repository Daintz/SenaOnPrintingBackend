using DataCape.Models;
using PersistenceCape.Interfaces;
using PersistenceCape.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.Services
{
    public class AuthenticationService
    {
        private readonly IAuthenticationRepository _repository;

        public AuthenticationService(IAuthenticationRepository repository)
        {
            _repository = repository;
        }

        /*public bool Authenticate(string email, string password)
        {
            return _repository.Authenticate(email, password);
        }*/

        public async Task<UserModel> Authenticate(string email, string password)
        {
            return await _repository.Authenticate(email, password);
        }
        public void CloseSession(string token)
        {
            _repository.CloseSession(token);
        }
        public async Task<UserModel> ForgotPassword(string email)
        {
            return await _repository.ForgotPassword(email);
        }

        public async Task<bool> RecoveryPassword(string email, string token, string password, string confirmPassword)
        {
            return await _repository.RecoveryPassword(email, token, password, confirmPassword);
        }
    }
}
