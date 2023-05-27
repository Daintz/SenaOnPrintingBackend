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

        public async Task AddAsync(Warehouse Warehause)
        {
            await _WarehauseRepository.AddAsync(Warehause);
        }

        public Task DeleteAsync(long id)
        {
            return _WarehauseRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<Warehouse>> GetAllAsync()
        {
            return _WarehauseRepository.GetAllAsync();
        }

        public Task<Warehouse> GetByIdAsync(long id)
        {
            return _WarehauseRepository.GetByIdAsync(id);
        }

        public Task UpdateAsync(Warehouse Warehause)
        {
            return _WarehauseRepository.UpdateAsync(Warehause);
        }
    }
}
