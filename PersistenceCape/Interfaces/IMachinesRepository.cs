
using DataCape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Interfaces
{
    public interface IMachinesRepository
    {
        Task<IEnumerable<Machine>> GetAllAsync();
        Task<Machine> GetByIdAsync(long id);
        Task<Machine> AddAsync(Machine machine);
        Task UpdateAsync(Machine machine);
        Task DeleteAsync(long id);
    }
}
