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
        Task<IEnumerable<Supply>> GetAllAsync();
        Task<Supply> GetByIdAsync(long id);
        Task<Supply> AddAsync(Supply supplyCategory);
        Task UpdateAsync(Supply supplyCategory);
        Task DeleteAsync(long id);
    }
}
