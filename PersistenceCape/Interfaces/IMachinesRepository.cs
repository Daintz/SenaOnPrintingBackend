
using DataCape;
using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Interfaces
{
    public interface IMachinesRepository
    {
        Task<IEnumerable<MachineModel>> GetAllAsync();
        Task<MachineModel> GetByIdAsync(long id);
        Task<MachineModel> AddAsync(MachineModel machine);
        Task UpdateAsync(MachineModel machine);
        Task DeleteAsync(long id);
    }
}
