using DataCape.Models;

namespace PersistenceCape.Interfaces
{
    public interface ISupplyCategoryRepository
    {
        Task<IEnumerable<SupplyCategory>> GetAllAsync();
        Task<SupplyCategory> GetByIdAsync(long id);
        Task<SupplyCategory> AddAsync(SupplyCategory supplyCategory);
        Task UpdateAsync(SupplyCategory supplyCategory);
        Task DeleteAsync(long id);
    }
}
