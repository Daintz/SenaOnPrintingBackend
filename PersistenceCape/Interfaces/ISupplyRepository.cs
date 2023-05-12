using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Interfaces
{
    public interface ISupplyRepository
    {
        Task<IEnumerable<SupplyModel>> GetAllAsync();
        Task<SupplyModel> GetByIdAsync(Guid id);
        Task<SupplyModel> AddAsync(SupplyModel supplyCategory);
        Task UpdateAsync(SupplyModel supplyCategory);
        Task DeleteAsync(Guid id);
    }
}
