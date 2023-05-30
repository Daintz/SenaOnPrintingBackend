using DataCape;
using DataCape.Models;
using PersistenceCape.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.Services
{
    public class SupplyPictogramsServices
    {
        private readonly ISupplyPictogramsRepository _SupplyPictogramRepository;

        public SupplyPictogramsServices(ISupplyPictogramsRepository supplyPictogramRepository)
        {
            _SupplyPictogramRepository = supplyPictogramRepository;
        }

        public async Task<IEnumerable<SupplyPictogramModel>> GetAllAsync()
        {
            return await _SupplyPictogramRepository.GetAllAsync();
        }

        public async Task<SupplyPictogramModel> GetByIdAsync(long id)
        {
            return await _SupplyPictogramRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(SupplyPictogramModel SupplyPictogramRepository)
        {
            await _SupplyPictogramRepository.AddAsync(SupplyPictogramRepository);
        }

        public async Task UpdateAsync(SupplyPictogramModel SupplyPictogramRepository)
        {
            await _SupplyPictogramRepository.UpdateAsync(SupplyPictogramRepository);
        }

        public async Task DeleteAsync(long id)
        {
            await _SupplyPictogramRepository.DeleteAsync(id);
        }
    }
}
