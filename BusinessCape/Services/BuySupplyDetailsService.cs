using DataCape.Models;
using PersistenceCape.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.Services
{
    public class BuySupplyDetailsService
    {
        private readonly IBuySuppliesDetailRepository _BuySupplyDetailsRepository;

        public BuySupplyDetailsService(IBuySuppliesDetailRepository BuySupplyDetailsRepository)
        {
            _BuySupplyDetailsRepository = BuySupplyDetailsRepository;
        }

        public async Task<IEnumerable<BuySuppliesDetailModel>> GetAllAsync()
        {
            return await _BuySupplyDetailsRepository.GetAllAsync();
        }
        //public async Task<IEnumerable<BuySuppliesDetail>> GetApprovedQuotationAsync()
        //{
        //    return await _BuySupplyDetailsRepository.GetApprovedQuotationAsync();
        //}
        public async Task<BuySuppliesDetailModel> GetByIdAsync(long id)
        {
            return await _BuySupplyDetailsRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(BuySuppliesDetailModel buySupplyDetailsCreate)
        {
            await _BuySupplyDetailsRepository.AddAsync(buySupplyDetailsCreate);
        }

        public async Task UpdateAsync(BuySuppliesDetailModel buySupplyDetailsToUpdate)
        {
            await _BuySupplyDetailsRepository.UpdateAsync(buySupplyDetailsToUpdate);
        }

        public async Task DeleteAsync(long id)
        {
            await _BuySupplyDetailsRepository.DeleteAsync(id);
        }
    }
}
