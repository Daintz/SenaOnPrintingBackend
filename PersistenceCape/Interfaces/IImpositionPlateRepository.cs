using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Interfaces
{
    public interface IImpositionPlateRepository
    {
        Task<IEnumerable<ImpositionPlateModel>> GetAllAsync();
        Task<ImpositionPlateModel> GetByIdAsync(long id);
        Task<ImpositionPlateModel> AddAsync(ImpositionPlateModel impositionPlate);
        Task UpdateAsync(ImpositionPlateModel impositionPlate);
        Task ChangeState(long id);
    }
}
