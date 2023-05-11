using DataCape.Models;

namespace PersistenceCape.Interfaces
{
    public interface ISupplyCategoryRepository
    {
        Task<IEnumerable<SupplyCategoryModel>> GetAllAsync();
        Task<SupplyCategoryModel> GetByIdAsync(long id);
        Task<SupplyCategoryModel> AddAsync(SupplyCategoryModel supplyCategory);
        Task UpdateAsync(SupplyCategoryModel supplyCategory);
        Task DeleteAsync(long id);
    }
}
