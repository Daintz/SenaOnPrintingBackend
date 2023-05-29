using DataCape.Models;
using PersistenceCape.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.Services
{
    public class WarehauseTypeService
    {
        private readonly IWarehausetypeRepository _WarehausetypeRepository;

        public WarehauseTypeService(IWarehausetypeRepository WarehausetypeRepository)
        {
            _WarehausetypeRepository = WarehausetypeRepository;
        }

        public async Task AddAsync(WarehouseTypeModel WarehouseType)
        {
            await _WarehausetypeRepository.AddAsync(WarehouseType);
        }

        public Task DeleteAsync(long id)
        {
            return _WarehausetypeRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<WarehouseTypeModel>> GetAllAsync()
        {
            return _WarehausetypeRepository.GetAllAsync();
        }

        public Task<WarehouseTypeModel> GetByIdAsync(long id)
        {
            return _WarehausetypeRepository.GetByIdAsync(id);
        }

        public Task UpdateAsync(WarehouseTypeModel Warehause)
        {
            return _WarehausetypeRepository.UpdateAsync(Warehause);
        }
    }
}
