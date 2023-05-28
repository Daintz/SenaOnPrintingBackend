using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Interfaces
{
    public interface IClientsRepository
    {
        Task<IEnumerable<ClientModel>> GetAllAsync();
        Task<ClientModel> GetByIdAsync(long id);
        Task<ClientModel> AddAsync(ClientModel client);
        Task UpdateAsync(ClientModel client);
        Task DeleteAsync(long id);
    }
}
