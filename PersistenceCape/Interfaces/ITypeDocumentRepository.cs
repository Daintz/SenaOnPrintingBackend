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
        Task<IEnumerable<TypeDocumentModel>> Index();
        Task<TypeDocumentModel> Show(long id);
        Task<TypeDocumentModel> Create(TypeDocumentModel typeDocument);
        Task Update(TypeDocumentModel typeDocument);
        Task Delete(long id);
    }
}
