using DataCape.Models;
using PersistenceCape.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.Services
{
    public class GrammageCaliberService
    {
        private readonly IGrammageCaliberRepository _grammageCaliberRepository;

        public GrammageCaliberService(IGrammageCaliberRepository grammageCaliberRepository)
        {
            _grammageCaliberRepository = grammageCaliberRepository;
        }

        public async Task<IEnumerable<GrammageCaliberModel>> GetAllAsync()
        {
            return await _grammageCaliberRepository.GetAllAsync();
        }

        public async Task<GrammageCaliberModel> GetByIdAsync(long id)
        {
            return await _grammageCaliberRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(GrammageCaliberModel grammageCaliber)
        {
            await _grammageCaliberRepository.AddAsync(grammageCaliber);
        }

        public async Task UpdateAsync(GrammageCaliberModel grammageCaliber)
        {
            await _grammageCaliberRepository.UpdateAsync(grammageCaliber);
        }

        public async Task DeleteAsync(long id)
        {
            await _grammageCaliberRepository.DeleteAsync(id);
        }
    }
}
