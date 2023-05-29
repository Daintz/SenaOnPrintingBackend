using PersistenceCape.Interfaces;
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

        public bool Authenticate(string email, string password)
        {
            return _repository.Authenticate(email, password);
        }

        public void CloseSession(string token)
        {
            _repository.CloseSession(token);
        }
    }
}
