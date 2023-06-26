using DataCape.Models;
using Microsoft.AspNetCore.Http;
using PersistenceCape.Interfaces;


namespace BusinessCape.Services
{
    public class ImpositionPlanchService
    {
        private readonly IImpositionPlanchRepository _impositionPlanchRepository;

        public ImpositionPlanchService(IImpositionPlanchRepository impositionPlateRepository)
        {
            _impositionPlanchRepository = impositionPlateRepository;
        }

        public async Task<IEnumerable<ImpositionPlanchModel>> GetAllAsync()
        {
            
            return await _impositionPlanchRepository.GetAllAsync();
        }

        public async Task<ImpositionPlanchModel> GetByIdAsync(long id)
        {
            return await _impositionPlanchRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(ImpositionPlanchModel impositionPlateRepository)
        {
            await _impositionPlanchRepository.AddAsync(impositionPlateRepository);
        }

        public async Task UpdateAsync(ImpositionPlanchModel impositionPlateRepository)
        {
            await _impositionPlanchRepository.UpdateAsync(impositionPlateRepository);
        }

        public async Task ChangeState(long id)
        {
            await _impositionPlanchRepository.ChangeState(id);
        }
    }
}
