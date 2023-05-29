using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Interfaces
{
    public interface IGrammageCaliberRepository
    {
        Task<IEnumerable<GrammageCaliberModel>> GetAllAsync();
        Task<GrammageCaliberModel> GetByIdAsync(long id);
        Task<GrammageCaliberModel> AddAsync(GrammageCaliberModel grammageCaliber);
        Task UpdateAsync(GrammageCaliberModel grammageCaliber);
        Task DeleteAsync(long id);
    }
}
