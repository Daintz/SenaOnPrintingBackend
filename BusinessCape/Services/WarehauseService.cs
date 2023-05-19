using DataCape.Models;
using PersistenceCape.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.Services
{
    public class WarehauseService
    {
        private readonly IWarehauseRepository _WarehauseRepository;

        public WarehauseService(IWarehauseRepository WarehauseRepository)
        {
            _WarehauseRepository = WarehauseRepository;
        }

        public async Task AddAsync(WarehouseModel Warehause)
        {
            await _WarehauseRepository.AddAsync(Warehause);
        }

        public Task DeleteAsync(long id)
        {
            return _WarehauseRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<WarehouseModel>> GetAllAsync()
        {
            return _WarehauseRepository.GetAllAsync();
        }

        public Task<WarehouseModel> GetByIdAsync(long id)
        {
            return _WarehauseRepository.GetByIdAsync(id);
        }

        public Task UpdateAsync(WarehouseModel Warehause)
        {
            return _WarehauseRepository.UpdateAsync(Warehause);
        }
    }
}
