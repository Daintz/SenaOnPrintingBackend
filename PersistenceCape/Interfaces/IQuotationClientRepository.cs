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
        Task<QuotationClientModel> GetByIdAsync(long Id);
        Task<QuotationClientModel> AddAsync(QuotationClientModel quotationclient);
        Task UpdateAsync(QuotationClientModel quotationclient);
        Task DeleteAsync(long Id);
    }
}
