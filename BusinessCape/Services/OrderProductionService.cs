using DataCape.Models;
using PersistenceCape.Interfaces;
using PersistenceCape.Repositories;

namespace BusinessCape.Services
{
    public class OrderProductionService
    {
        private readonly IOrderProductionRepository _orderProductionRepository;

        public OrderProductionService(IOrderProductionRepository orderProductionRepository)
        {
            _orderProductionRepository = orderProductionRepository;
        }

        public async Task<IEnumerable<OrderProductionModel>> GetAllAsync()
        {
            return await _orderProductionRepository.GetAllAsync();
        }

        public async Task<OrderProductionModel> GetByIdAsync(long id)
        {
            return await _orderProductionRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(OrderProductionModel orderProduction)
        {
            await _orderProductionRepository.AddAsync(orderProduction);
        }

        public async Task UpdateAsync(OrderProductionModel orderProduction)
        {
            await _orderProductionRepository.UpdateAsync(orderProduction);
        }

        public async Task ChangeState(long id)
        {
            await _orderProductionRepository.ChangeState(id);
        }
        public async Task ChangeOrderStatus(long id)
        {
            await _orderProductionRepository.ChangeOrderStatus(id);
        }
    }
}
