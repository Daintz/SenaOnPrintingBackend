using DataCape;
using DataCape.Models;
using PersistenceCape.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.Services
{
    public class FinishServices
    {

        private readonly IFinishs _FinishRepository;

        public FinishServices(IFinishs finishRepository)
        {
            _FinishRepository = finishRepository;
        }

        public async Task<IEnumerable<FinishModel>> GetAllAsync()
        {
            return await _FinishRepository.GetAllAsync();
        }

        public async Task<FinishModel> GetByIdAsync(long id)
        {
            return await _FinishRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(FinishModel finish)
        {
            await _FinishRepository.AddAsync(finish);
        }

        public async Task UpdateAsync(FinishModel finish)
        {
            await _FinishRepository.UpdateAsync(finish);
        }

        public async Task DeleteAsync(long id)
        {
            await _FinishRepository.DeleteAsync(id);
        }
    }
}

