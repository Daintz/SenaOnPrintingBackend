using DataCape.Items;

namespace PersistenceCape.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<UserItem> GetUsers();
        UserItem GetById(int id);
        void Add(UserItem item);
        void Update(UserItem item);
        void Delete(int id);
    }
}
