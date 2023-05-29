using DataCape.Models;
using PersistenceCape.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.Services
{
    public class QuotationClientDetailService
    {
        private readonly IQuotationClientDetailRepository _quotationclientDetailRepository;

        public QuotationClientDetailService(IQuotationClientDetailRepository quotationclientDetailRepository)
        {
            _quotationclientDetailRepository = quotationclientDetailRepository;
        }

        public async Task<IEnumerable<QuotationClientDetailModel>> GetAllAsync()
        {
            return await _quotationclientDetailRepository.GetAllAsync();
        }

        public async Task<QuotationClientDetailModel> GetByIdAsync(long id)
        {
            return await _quotationclientDetailRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(QuotationClientDetailModel quotationclientDetail)
        {
            await _quotationclientDetailRepository.AddAsync(quotationclientDetail);
        }

        public async Task UpdateAsync(QuotationClientDetailModel quotationclientDetail)
        {
            await _quotationclientDetailRepository.UpdateAsync(quotationclientDetail);
        }

        public async Task DeleteAsync(long id)
        {
            await _quotationclientDetailRepository.DeleteAsync(id);
        }
    }
}
