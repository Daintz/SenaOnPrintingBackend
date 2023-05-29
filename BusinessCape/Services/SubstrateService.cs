using DataCape.Models;
using PersistenceCape.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.Services
{
    public class SubstrateService
    {
        private readonly ISubstratesRepository _substrateRepository;

        public SubstrateService(ISubstratesRepository substrateRepository)
        {
            _substrateRepository = substrateRepository;
        }

        public async Task<IEnumerable<SubstrateModel>> GetAllAsync()
        {
            return await _substrateRepository.GetAllAsync();
        }

        public async Task<SubstrateModel> GetByIdAsync(long id)
        {
            return await _substrateRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(SubstrateModel substrate)
        {
            await _substrateRepository.AddAsync(substrate);
        }

        public async Task UpdateAsync(SubstrateModel substrate)
        {
            await _substrateRepository.UpdateAsync(substrate);
        }

        public async Task DeleteAsync(long id)
        {
            await _substrateRepository.DeleteAsync(id);
        }
    }
}
