using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Interfaces
{
    public interface IBuySuppliesDetailRepository
    {
        Task<IEnumerable<BuySuppliesDetailModel>> GetAllAsync();
        //Task<IEnumerable<BuySuppliesDetailModel>> GetApprovedQuotationAsync();
        Task<BuySuppliesDetailModel> GetByIdAsync(long id);
        Task<BuySuppliesDetailModel> AddAsync(BuySuppliesDetailModel buySuppliesDetailCreate);
        Task UpdateAsync(BuySuppliesDetailModel buySuppliesDetailToUpdate);
        Task DeleteAsync(long id);
    }
}
