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
        Task<IEnumerable<Provider>> GetAllAsync();
        Task<Provider> GetByIdAsync(long id);
        Task<Provider> AddAsync(Provider Provider);
        Task UpdateAsync(Provider Provider);
        Task DeleteAsync(long id);
    }
}
