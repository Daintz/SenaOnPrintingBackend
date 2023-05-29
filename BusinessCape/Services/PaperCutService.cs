using DataCape.Models;
using PersistenceCape.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.Services
{
    public class PaperCutService
    {
        private readonly IPaperCutRepository _paperCutRepository;

        public PaperCutService(IPaperCutRepository paperCutRepository)
        {
            _paperCutRepository = paperCutRepository;
        }

        public async Task<IEnumerable<PaperCutModel>> GetAllAsync()
        {
            return await _paperCutRepository.GetAllAsync();
        }

        public async Task<PaperCutModel> GetByIdAsync(long id)
        {
            return await _paperCutRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(PaperCutModel paperCut)
        {
            await _paperCutRepository.AddAsync(paperCut);
        }

        public async Task UpdateAsync(PaperCutModel paperCut)
        {
            await _paperCutRepository.UpdateAsync(paperCut);
        }

        public async Task DeleteAsync(long id)
        {
            await _paperCutRepository.DeleteAsync(id);
        }
    }
}
