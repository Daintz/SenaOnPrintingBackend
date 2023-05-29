using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Interfaces
{
    public interface ISubstratesRepository
    {
        Task<IEnumerable<SubstrateModel>> GetAllAsync();
        Task<SubstrateModel> GetByIdAsync(long id);
        Task<SubstrateModel> AddAsync(SubstrateModel substrate);
        Task UpdateAsync(SubstrateModel substrate);
        Task DeleteAsync(long id);
    }
}
