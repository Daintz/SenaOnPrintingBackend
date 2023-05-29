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
        Task<IEnumerable<WarehouseModel>> GetAllAsync();
        Task<WarehouseModel> GetByIdAsync(long id);
        Task<WarehouseModel> AddAsync(WarehouseModel Warehouse);
        Task UpdateAsync(WarehouseModel Warehouse);
        Task DeleteAsync(long id);
    }
}
