using DataCape;
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

        public async Task<IEnumerable<Finish>> GetAllAsync()
        {
            return await _FinishRepository.GetAllAsync();
        }

        public async Task<Finish> GetByIdAsync(long id)
        {
            return await _FinishRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Finish finish)
        {
            await _FinishRepository.AddAsync(finish);
        }

        public async Task UpdateAsync(Finish finish)
        {
            await _FinishRepository.UpdateAsync(finish);
        }

        public async Task DeleteAsync(long id)
        {
            await _FinishRepository.DeleteAsync(id);
        }
    }
}

