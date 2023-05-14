using DataCape.Models;
using PersistenceCape.Interfaces;

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

        public async Task<SupplyModel> GetByIdAsync(Guid id)
        {
            return await _supplyRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(SupplyModel supplyCategory)
        {
            await _supplyRepository.AddAsync(supplyCategory);
        }

        public async Task UpdateAsync(SupplyModel supplyCategory)
        {
            await _supplyRepository.UpdateAsync(supplyCategory);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _supplyRepository.DeleteAsync(id);
        }
    }
}
