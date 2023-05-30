
using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PersistenceCape.Interfaces
{
    public interface ISupplyPictogramsRepository
    {
        Task<IEnumerable<SupplyPictogramModel>> GetAllAsync();
        Task<SupplyPictogramModel> GetByIdAsync(long id);
        Task<SupplyPictogramModel> AddAsync(SupplyPictogramModel supplyPictogram);
        Task UpdateAsync(SupplyPictogramModel supplyPictogram);
        Task DeleteAsync(long id);
    }
}
