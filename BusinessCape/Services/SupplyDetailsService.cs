using DataCape.Models;
using PersistenceCape.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessCape.Services
{
    public class SupplyDetailsService

    {
        private readonly ISupplyDetailsRepository _supplyDetailRepository;

        public SupplyDetailsService(ISupplyDetailsRepository supplyDetailRepository)
        {
            _supplyDetailRepository = supplyDetailRepository;
        }

        public async Task<IEnumerable<SupplyDetailModel>> GetAllAsync()
        {
            return await _supplyDetailRepository.GetAllAsync();
        }

        public async Task<SupplyDetailModel> GetByIdAsync(long id)
        {
            return await _supplyDetailRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(SupplyDetailModel supplyDetail)
        {
            await _supplyDetailRepository.AddAsync(supplyDetail);
        }

        public async Task UpdateAsync(SupplyDetailModel supplyDetail)
        {
            await _supplyDetailRepository.UpdateAsync(supplyDetail);
        }

        public async Task ChangeState(long id)
        {
            await _supplyDetailRepository.ChangeState(id);
        }
    }
}
