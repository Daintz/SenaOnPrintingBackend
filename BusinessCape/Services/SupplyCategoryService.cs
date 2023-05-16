using DataCape.Models;
using PersistenceCape.Interfaces;

namespace BusinessCape.Services
{
    public class SupplyCategoryService
    {
        private readonly ISupplyCategoryRepository _supplyCategoryRepository;

        public SupplyCategoryService(ISupplyCategoryRepository supplyCategoryRepository)
        {
            _supplyCategoryRepository = supplyCategoryRepository;
        }

        public async Task<IEnumerable<SupplyCategoryModel>> GetAllAsync()
        {
            return await _supplyCategoryRepository.GetAllAsync();
        }

        public async Task<SupplyCategoryModel> GetByIdAsync(long id)
        {
            return await _supplyCategoryRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(SupplyCategoryModel supplyCategory)
        {
            await _supplyCategoryRepository.AddAsync(supplyCategory);
        }

        public async Task UpdateAsync(SupplyCategoryModel supplyCategory)
        {
            await _supplyCategoryRepository.UpdateAsync(supplyCategory);
        }

        public async Task DeleteAsync(long id)
        {
            await _supplyCategoryRepository.DeleteAsync(id);
        }
    }
}
