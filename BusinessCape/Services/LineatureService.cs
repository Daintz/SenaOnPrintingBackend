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
    public class LineatureService
    {
        private readonly ILineatureRepository _lineatureRepository;

        public LineatureService(ILineatureRepository lineatureRepository)
        {
            _lineatureRepository = lineatureRepository;
        }

        public async Task<IEnumerable<LineatureModel>> GetAllAsync()
        {
            return await _lineatureRepository.GetAllAsync();
        }

        public async Task<LineatureModel> GetByIdAsync(long id)
        {
            return await _lineatureRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(LineatureModel lineatureRepository)
        {
            await _lineatureRepository.AddAsync(lineatureRepository);
        }

        public async Task UpdateAsync(LineatureModel lineatureRepository)
        {
            await _lineatureRepository.UpdateAsync(lineatureRepository);
        }

        public async Task ChangeState(long id)
        {
            await _lineatureRepository.ChangeState(id);
        }
    }
}
