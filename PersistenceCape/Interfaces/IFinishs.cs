
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
        Task<IEnumerable<FinishModel>> GetAllAsync();
        Task<FinishModel> GetByIdAsync(long id);
        Task<FinishModel> AddAsync(FinishModel finish);
        Task UpdateAsync(FinishModel finish);
        Task DeleteAsync(long id);
    }
}
