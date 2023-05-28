using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Interfaces
{
    public interface IPaperCutRepository
    {
        Task<IEnumerable<PaperCutModel>> GetAllAsync();
        Task<PaperCutModel> GetByIdAsync(long id);
        Task<PaperCutModel> AddAsync(PaperCutModel paperCut);
        Task UpdateAsync(PaperCutModel paperCut);
        Task DeleteAsync(long id);
    }
}
