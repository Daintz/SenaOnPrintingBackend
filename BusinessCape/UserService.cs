using DataCape;
using PersistenceCape.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape
{
    public class UserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<UserItem> GetUsers()
        {
            return _repository.GetUsers();
        }
    }
}
