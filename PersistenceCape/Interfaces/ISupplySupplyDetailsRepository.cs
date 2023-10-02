using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Interfaces
{
    public interface ISupplySupplyDetailsRepository
    {
        Task<IEnumerable<SupplySupplyDetailsModel>> GetAllAsync();
        Task<SupplySupplyDetailsModel> GetByIdAsync(long id);
        Task<SupplySupplyDetailsModel> AddAsync(SupplySupplyDetailsModel supplySupplyDetail);
        Task UpdateAsync(SupplySupplyDetailsModel supplySupplyDetail);
    }
}
