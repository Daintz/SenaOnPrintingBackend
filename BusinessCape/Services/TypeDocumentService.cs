using DataCape.Models;
using PersistenceCape.Interfaces;

namespace BusinessCape.Services
{
    public class TypeDocumentService
    {
        private readonly ITypeDocumentRepository _typeDocumentRepository;

        public TypeDocumentService(ITypeDocumentRepository typeDocumentRepository)
        {
            _typeDocumentRepository = typeDocumentRepository;
        }

        public async Task<IEnumerable<TypeDocument>> Index()
        {
            return await _typeDocumentRepository.Index();
        }

        public async Task<TypeDocument> Show(long id)
        {
            return await _typeDocumentRepository.Show(id);
        }

        public async Task Create(TypeDocument typeDocument)
        {
            await _typeDocumentRepository.Create(typeDocument);
        }

        public async Task Update(TypeDocument typeDocument)
        {
            await _typeDocumentRepository.Update(typeDocument);
        }

        public async Task Delete(long id)
        {
            await _typeDocumentRepository.Delete(id);
        }
    }
}
