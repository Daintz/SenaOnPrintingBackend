using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Interfaces
{
    public interface IWarehauseRepository
    {
        Task<IEnumerable<Warehouse>> GetAllAsync();
        Task<Warehouse> GetByIdAsync(long id);
        Task<Warehouse>AddAsync(Warehouse Warehouse);
        Task UpdateAsync(Warehouse Warehouse);
        Task DeleteAsync(long id);
    }
}
