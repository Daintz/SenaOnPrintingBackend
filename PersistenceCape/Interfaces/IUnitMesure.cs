
using DataCape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Interfaces
{
    public interface IUnitMesure
    {
        Task<IEnumerable<UnitMeasureModel>> GetAllAsync();
        Task<UnitMeasureModel> GetByIdAsync(long id);
        Task<UnitMeasureModel> AddAsync(UnitMeasureModel Unit);
        Task UpdateAsync(UnitMeasureModel Unit);
        Task DeleteAsync(long id);
    }
}
