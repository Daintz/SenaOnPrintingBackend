using DataCape.Models;
using PersistenceCape.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.Services
{
    public class TypeServicesServices
    {
        private readonly ITypeServicesRepository _typeServicesRepository;

        public TypeServicesServices(ITypeServicesRepository typeServicesRepository)
        {
            _typeServicesRepository = typeServicesRepository;
        }

        public async Task<IEnumerable<TypeServiceModel>> GetAllAsync()
        {
            return await _typeServicesRepository.GetAllAsync();
        }

        public async Task<TypeServiceModel> GetByIdAsync(long id)
        {
            return await _typeServicesRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(TypeServiceModel typeServicesRepository)
        {
            await _typeServicesRepository.AddAsync(typeServicesRepository);
        }

        public async Task UpdateAsync(TypeServiceModel typeServicesRepository)
        {
            await _typeServicesRepository.UpdateAsync(typeServicesRepository);
        }

        public async Task DeleteAsync(long id)
        {
            await _typeServicesRepository.DeleteAsync(id);
        }
    }
}
