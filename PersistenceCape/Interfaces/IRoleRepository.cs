using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> Index();
        Task<Role> Show(long id);
        Task<Role> Create(Role role);
        Task Update(Role role);
        Task Delete(long id);
    }
}
