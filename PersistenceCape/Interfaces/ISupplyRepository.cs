using DataCape.Models;

namespace PersistenceCape.Interfaces
{
    public interface ISupplyRepository
    {
        Task<IEnumerable<SupplyModel>> GetAllAsync();
        Task<SupplyModel> GetByIdAsync(long id);
        Task<SupplyModel> AddAsync(SupplyModel supplyCategory);
        Task UpdateAsync(SupplyModel supplyCategory);
        Task DeleteAsync(long id);
    }
}
