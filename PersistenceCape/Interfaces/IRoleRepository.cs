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
        Task<IEnumerable<RoleModel>> Index();
        Task<RoleModel> Show(long id);
        Task<RoleModel> Create(RoleModel role);
        Task Update(RoleModel role);
        Task Delete(long id);
    }
}
