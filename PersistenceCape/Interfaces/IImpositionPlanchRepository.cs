using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Interfaces
{
    public interface IImpositionPlanchRepository
    {
        Task<IEnumerable<ImpositionPlanchModel>> GetAllAsync();
        Task<ImpositionPlanchModel> GetByIdAsync(long id);
        Task<ImpositionPlanchModel> AddAsync(ImpositionPlanchModel impositionPlate);
        Task UpdateAsync(ImpositionPlanchModel impositionPlate);
        Task ChangeState(long id);
    }
}
