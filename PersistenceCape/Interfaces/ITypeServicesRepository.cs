using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Interfaces
{
    public interface ITypeServicesRepository
    {
        Task<IEnumerable<TypeServiceModel>> GetAllAsync();
        Task<TypeServiceModel> GetByIdAsync(long id);
        Task<TypeServiceModel> AddAsync(TypeServiceModel typeService);
        Task UpdateAsync(TypeServiceModel typeServices);
        Task DeleteAsync(long id);
    }
}
