using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Interfaces
{
    public interface IProviderRepository
    {
        Task<IEnumerable<ProviderModel>> GetAllAsync();
        Task<ProviderModel> GetByIdAsync(long id);
        Task<ProviderModel> AddAsync(ProviderModel Provider);
        Task UpdateAsync(ProviderModel Provider);
        Task DeleteAsync(long id);
    }
}
