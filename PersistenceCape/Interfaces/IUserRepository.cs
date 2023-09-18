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
        Task<IEnumerable<UserModel>> Index();
        Task<UserModel> Show(long id);
        Task<UserModel> Create(UserModel user);
        Task Update(UserModel user);
        Task UpdateProfile(UserModel user);
        Task Delete(long id);
    }
}
