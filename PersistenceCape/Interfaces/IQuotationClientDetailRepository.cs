using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Interfaces
{
    public interface IQuotationClientDetailRepository
    {
        Task<IEnumerable<QuotationClientDetailModel>> GetAllAsync();
        Task<IEnumerable<QuotationClientDetailModel>> GetApprovedQuotationAsync();
        Task<QuotationClientDetailModel> GetByIdAsync(long id);
        Task<QuotationClientDetailModel> AddAsync(QuotationClientDetailModel quotationclientDetail);
        Task UpdateAsync(QuotationClientDetailModel quotationclientDetail);
        Task DeleteAsync(long id);
    }
}
