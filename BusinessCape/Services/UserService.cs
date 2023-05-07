using DataCape.Items;
using PersistenceCape.Interfaces;

namespace BusinessCape.Services
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

        public UserItem GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(UserItem item)
        {
            _repository.Add(item);
        }

        public void Update(UserItem item)
        {
            _repository.Update(item);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
