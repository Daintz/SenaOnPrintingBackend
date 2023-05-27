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
        Task<IEnumerable<WarehouseTypeModel>> GetAllAsync();
        Task<WarehouseTypeModel> GetByIdAsync(long id);
        Task<WarehouseTypeModel> AddAsync(WarehouseTypeModel warehouseType);
        Task UpdateAsync(WarehouseTypeModel warehouseType);
        Task DeleteAsync(long id);
    }
}

