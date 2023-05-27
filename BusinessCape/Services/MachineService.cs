using DataCape.Models;
using PersistenceCape.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.Services
{
    public class MachineService
    {


        private readonly  IMachinesRepository _MachineRepository;

        public MachineService(IMachinesRepository MachineRepository)
        {
            _MachineRepository = MachineRepository;
        }

        public async Task<IEnumerable<MachineModel>> GetAllAsync()
        {
            return await _MachineRepository.GetAllAsync();
        }

        public async Task<MachineModel> GetByIdAsync(long id)
        {
            return await _MachineRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(MachineModel machine)
        {
            await  _MachineRepository.AddAsync(machine);
        }

        public async Task UpdateAsync(MachineModel machine)
        {
            await _MachineRepository.UpdateAsync(machine);
        }

        public async Task DeleteAsync(long id)
        {
            await _MachineRepository.DeleteAsync(id);
        }
    }
}
