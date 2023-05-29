using DataCape.Models;


namespace PersistenceCape.Interfaces
{
    public interface ILineatureRepository
    {
        Task<IEnumerable<LineatureModel>> GetAllAsync();
        Task<LineatureModel> GetByIdAsync(long id);
        Task<LineatureModel> AddAsync(LineatureModel lineture);
        Task UpdateAsync(LineatureModel lineture);
        Task ChangeState(long id);
    }
}
