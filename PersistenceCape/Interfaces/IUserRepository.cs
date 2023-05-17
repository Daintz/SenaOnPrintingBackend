using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> Index();
        Task<User> Show(long id);
        Task<User> Create(User user);
        Task Update(User user);
        Task Delete(long id);
    }
}
