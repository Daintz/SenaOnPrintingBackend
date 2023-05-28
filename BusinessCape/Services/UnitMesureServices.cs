using DataCape;
using PersistenceCape.Interfaces;
using PersistenceCape.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.Services
{
    public class UnitMesureServices
    {

        private readonly IUnitMesure _UnitMesureRepository;

        public UnitMesureServices(IUnitMesure UnitMesureRepository)
        {
            _UnitMesureRepository = UnitMesureRepository;
        }

        public async Task<IEnumerable<UnitMeasureModel>> GetAllAsync()
        {
            return await _UnitMesureRepository.GetAllAsync();
        }

        public async Task<UnitMeasureModel> GetByIdAsync(long id)
        {
            return await _UnitMesureRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(UnitMeasureModel UnitMesureRepository)
        {
            await _UnitMesureRepository.AddAsync(UnitMesureRepository);
        }

        public async Task UpdateAsync(UnitMeasureModel UnitMesureRepository)
        {
            await _UnitMesureRepository.UpdateAsync(UnitMesureRepository);
        }

        public async Task DeleteAsync(long id)
        {
            await _UnitMesureRepository.DeleteAsync(id);
        }
    }
}

