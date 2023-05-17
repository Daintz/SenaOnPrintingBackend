using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Interfaces
{
    public interface ITypeDocumentRepository
    {
        Task<IEnumerable<TypeDocument>> Index();
        Task<TypeDocument> Show(long id);
        Task<TypeDocument> Create(TypeDocument typeDocument);
        Task Update(TypeDocument typeDocument);
        Task Delete(long id);
    }
}
