using DataCape.Models;
using PersistenceCape.Interfaces;
using PersistenceCape.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessCape.Services
{
    public class BuySupplyService

    {
        private readonly IBuySupplyRepository _buySupplyRepository;

        public BuySupplyService(IBuySupplyRepository buySupplyRepository)
        {
            _buySupplyRepository = buySupplyRepository;
        }

        public async Task<IEnumerable<BuySupplyModel>> Index()
        {
            return await _buySupplyRepository.Index();
        }

        public async Task<BuySupplyModel> Show(long id)
        {
            return await _buySupplyRepository.Show(id);
        }

        public async Task Create(BuySupplyModel buySupply)
        {
            await _buySupplyRepository.Create(buySupply);
        }

        public async Task Update(BuySupplyModel buySupply)
        {
            await _buySupplyRepository.Update(buySupply);
        }

        public async Task ChangeState(long id)
        {
            await _buySupplyRepository.ChangeState(id);
        }
    }
}
