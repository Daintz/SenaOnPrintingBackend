using DataCape.Models;
using PersistenceCape.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.Services
{
    public class QuotationClientService
    {
        private readonly IQuotationClientRepository _quotationclientrepository;

        public QuotationClientService(IQuotationClientRepository quotationclientrepository)
        {
            _quotationclientrepository = quotationclientrepository;
        }

        public async Task<IEnumerable<QuotationClientModel>> GetAllAsync()
        {
            return await _quotationclientrepository.GetAllAsync();
        }

        public async Task<QuotationClientModel> GetByIdAsync(long id)
        {
            return await _quotationclientrepository.GetByIdAsync(id);
        }

        public async Task AddAsync(QuotationClientModel quotationclient)
        {
            await _quotationclientrepository.AddAsync(quotationclient);
        }

        public async Task UpdateAsync(QuotationClientModel quotationclient)
        {
            await _quotationclientrepository.UpdateAsync(quotationclient);
        }

        public async Task DeleteAsync(long id)
        {
            await _quotationclientrepository.DeleteAsync(id);
        }
    }
}
