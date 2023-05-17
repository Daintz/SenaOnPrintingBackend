using DataCape.Models;
using Microsoft.EntityFrameworkCore;
using PersistenceCape.Contexts;
using PersistenceCape.Interfaces;

namespace PersistenceCape.Repositories
{
    public class TypeDocumentRepository : ITypeDocumentRepository
    {
        private readonly SENAONPRINTINGContext _context;

        public TypeDocumentRepository(SENAONPRINTINGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TypeDocument>> Index()
        {
            return await _context.TypeDocuments.ToListAsync();
        }

        public async Task<TypeDocument> Show(long id)
        {
            return await _context.TypeDocuments.FindAsync(id);
        }

        public async Task Update(TypeDocument typeDocument)
        {
            _context.Entry(typeDocument).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<TypeDocument> Create(TypeDocument typeDocument)
        {
            await _context.TypeDocuments.AddAsync(typeDocument);
            await _context.SaveChangesAsync();
            return typeDocument;
        }

        public async Task Delete(long id)
        {
            var typeDocument = await _context.TypeDocuments.FindAsync(id);
            typeDocument.StatedAt = false;
            await _context.SaveChangesAsync();
        }
    }
}
