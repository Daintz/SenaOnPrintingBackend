using DataCape.Models;
using persistencecape.repositories;
using PersistenceCape.Interfaces;
using PersistenceCape.Repositories;

namespace BusinessCape.Services
{
    public class SupplyService
    {
        private readonly ISupplyRepository _supplyRepository;

        public SupplyService(ISupplyRepository supplyRepository)
        {
            _supplyRepository = supplyRepository;
        }

        public async Task<IEnumerable<SupplyModel>> GetAllAsync()
        {
            return await _supplyRepository.GetAllAsync();
        }

        public async Task<SupplyModel> GetByIdAsync(long id)
        {
            return await _supplyRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(SupplyModel supply)
        {
            await _supplyRepository.AddAsync(supply);
        }

        public async Task UpdateAsync(SupplyModel supply)
        {
            await _supplyRepository.UpdateAsync(supply);
        }

        public async Task ChangeState(long id)
        {
            await _supplyRepository.ChangeState(id);
        }
       
    }
}
