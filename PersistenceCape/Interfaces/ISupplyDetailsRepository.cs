using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Interfaces
{
    public interface ISupplyDetailsRepository
    {
        Task<IEnumerable<SupplyDetailModel>> GetAllAsync();
        Task<SupplyDetailModel> GetByIdAsync(long id);
        Task<SupplyDetailModel> AddAsync(SupplyDetailModel supplyDetail);
        Task UpdateAsync(SupplyDetailModel supplyDetail);
        //Task<IEnumerable<SupplySupplyDetailsModel>> GetSupplyDetailsForSupplyAsync(long supplyDetail);


        Task ChangeState(long id);
    }
}
