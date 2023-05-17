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

        public async Task<IEnumerable<Supply>> GetAllAsync()
        {
            return await _supplyRepository.GetAllAsync();
        }

        public async Task<Supply> GetByIdAsync(long id)
        {
            return await _supplyRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Supply supplyCategory)
        {
            await _supplyRepository.AddAsync(supplyCategory);
        }

        public async Task UpdateAsync(Supply supplyCategory)
        {
            await _supplyRepository.UpdateAsync(supplyCategory);
        }

        public async Task DeleteAsync(long id)
        {
            await _supplyRepository.DeleteAsync(id);
        }
    }
}
