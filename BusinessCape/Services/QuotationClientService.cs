using DataCape.Models;
using PersistenceCape.Interfaces;
using PersistenceCape.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.Services
{
    public class QuotationClientService
    {
        private readonly IQuotationClientRepository _quotationClientRepository;

        public QuotationClientService(IQuotationClientRepository quotationClientRepository)
        {
            _quotationClientRepository = quotationClientRepository;
        }

        public async Task<IEnumerable<QuotationClientModel>> GetAllAsync()
        {
            return await _quotationClientRepository.GetAllAsync();
        }
        public async Task<IEnumerable<QuotationClientModel>> GetApprovedQuotationAsync()
        {
            return await _quotationClientRepository.GetApprovedQuotationAsync();
        }
        public async Task<QuotationClientModel> GetByIdAsync(long id)
        {
            return await _quotationClientRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(QuotationClientModel quotationClient)
        {
            await _quotationClientRepository.AddAsync(quotationClient);
        }

        public async Task UpdateAsync(QuotationClientModel quotationClient)
        {
            await _quotationClientRepository.UpdateAsync(quotationClient);
        }

        public async Task DeleteAsync(long id)
        {
            await _quotationClientRepository.DeleteAsync(id);
        }
        public async Task ChangeQuotationStatus(long id)
        {
            await _quotationClientRepository.ChangeStatusQuotation(id);
        }
    }
}
