
using DataCape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Interfaces
{
    public interface IFinishs
    {
        Task<IEnumerable<Finish>> GetAllAsync();
        Task<Finish> GetByIdAsync(long id);
        Task<Finish> AddAsync(Finish finish);
        Task UpdateAsync(Finish finish);
        Task DeleteAsync(long id);
    }
}
