using DataCape.Models;


namespace PersistenceCape.Interfaces
{
    public interface IOrderProductionRepository
    {
        Task<IEnumerable<OrderProductionModel>> GetAllAsync();
        Task<OrderProductionModel> GetByIdAsync(long id);
        Task<OrderProductionModel> AddAsync(OrderProductionModel orderProduction);
        Task UpdateAsync(OrderProductionModel orderProduction);
        Task ChangeState(long id);
        Task ChangeOrderStatus(long id);
    }
}
