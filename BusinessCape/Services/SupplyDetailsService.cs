using DataCape.Models;
using persistencecape.repositories;
using PersistenceCape.Interfaces;
using PersistenceCape.Repositories;
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

        public async Task<IEnumerable<SupplyDetailModel>> GetSuppplySupplyAsync()
        {
            return await _supplyDetailRepository.GetSuppplySupplyAsync();
        }

        public async Task AddAsync(SupplyDetailModel supplyDetail)
        {
            supplyDetail.StatedAt = true;
            decimal? fullValue = 0;
            foreach (var supply in supplyDetail.Supplies)
            {
                fullValue += supply.Quantity * supply.SupplyCost;
            }
            supplyDetail.FullValue = (float)fullValue;

            await _supplyDetailRepository.AddAsync(supplyDetail);
        }

        public async Task UpdateAsync(SupplyDetailModel supplyDetail)
        {
            await _supplyDetailRepository.UpdateAsync(supplyDetail);
        }
        // Este método nuevo llama al método GetSupplySupplyDetailsForSupplyAsync() del repositorio para obtener los datos necesarios.

        //public async Task<IEnumerable<SupplyDetailModel>> GetSupplyDetailsWithSupplySupplyDetailsAsync(long supplyDetailsId)
        //{
        //    return await _supplyDetailRepository.GetSupplySupplyDetailsForSupplyAsync(supplyDetailsId);
        //}

        //public async Task<IEnumerable<SupplySupplyDetailsModel>> GetSupplyDetailsForSupplyAsync(long supplyDetail)
        //{
        //    return await _supplyDetailRepository.GetSupplyDetailsForSupplyAsync(supplyDetail);
        //}



        public async Task ChangeState(long id)
        {
            await _supplyDetailRepository.ChangeState(id);
        }
    }
}
