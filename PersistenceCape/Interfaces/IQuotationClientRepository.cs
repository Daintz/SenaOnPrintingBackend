using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Interfaces
{
    public interface IQuotationClientRepository
    {
        Task<IEnumerable<QuotationClientModel>> GetAllAsync();
        Task<IEnumerable<QuotationClientModel>> GetApprovedQuotationAsync();
        Task<QuotationClientModel> GetByIdAsync(long id);
        Task<QuotationClientModel> AddAsync(QuotationClientModel quotationClient);
        Task UpdateAsync(QuotationClientModel quotationClient);
        Task DeleteAsync(long id);

        Task ChangeStatusQuotation(long id);
    }
}
