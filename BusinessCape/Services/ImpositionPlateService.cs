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
    public class ImpositionPlateService
    {
        private readonly IImpositionPlateRepository _impositionPlateRepository;

        public ImpositionPlateService(IImpositionPlateRepository impositionPlateRepository)
        {
            _impositionPlateRepository = impositionPlateRepository;
        }

        public async Task<IEnumerable<ImpositionPlateModel>> GetAllAsync()
        {
            return await _impositionPlateRepository.GetAllAsync();
        }

        public async Task<ImpositionPlateModel> GetByIdAsync(long id)
        {
            return await _impositionPlateRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(ImpositionPlateModel impositionPlateRepository)
        {
            await _impositionPlateRepository.AddAsync(impositionPlateRepository);
        }

        public async Task UpdateAsync(ImpositionPlateModel impositionPlateRepository)
        {
            await _impositionPlateRepository.UpdateAsync(impositionPlateRepository);
        }

        public async Task ChangeState(long id)
        {
            await _impositionPlateRepository.ChangeState(id);
        }
    }
}
