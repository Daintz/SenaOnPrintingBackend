using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Interfaces
{
    public interface IQuotationProviderRepository
    {
        Task<IEnumerable<QuotationProviderModel>> GetAllAsync();
        Task<QuotationProviderModel> GetByIdAsync(long id);
        Task<QuotationProviderModel> AddAsync(QuotationProviderModel quotationProvider);
        Task UpdateAsync(QuotationProviderModel quotationProvider);
        Task DeleteAsync(long id);
    }

}
