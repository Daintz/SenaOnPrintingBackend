using DataCape.Models;

namespace PersistenceCape.Interfaces
{
    public interface ISupplyRepository
    {
        Task<IEnumerable<SupplyModel>> GetAllAsync();
        Task<SupplyModel> GetByIdAsync(long id);
        Task<SupplyModel> AddAsync(SupplyModel supply);
        Task UpdateAsync(SupplyModel supply);
        Task ChangeState(long id);
    }
}
