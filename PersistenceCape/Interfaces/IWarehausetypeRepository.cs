using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Interfaces
{
    public interface IWarehausetypeRepository
    {
        Task<IEnumerable<WarehouseType>> GetAllAsync();
        Task<WarehouseType> GetByIdAsync(long id);
        Task<WarehouseType> AddAsync(WarehouseType warehouseType);
        Task UpdateAsync(WarehouseType warehouseType);
        Task DeleteAsync(long id);
    }
}

