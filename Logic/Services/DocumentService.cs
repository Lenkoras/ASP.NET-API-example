using AutoMapper;
using Database.Models;
using Database.Repositories;
using Shared.Models;

namespace Logic.Services
{
    public class DocumentService : ServiceBase, IDocumentService
    {
        public IRepository<IdentifierDocument> Repository => RepositoryWrapper.Documents;
        public DocumentService(IRepositoryWrapper repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<DocumentFull> GetByIdAsync(string documentId)
        {
            var document = await Repository.FindAsync(documentId);
            return Mapper.Map<DocumentFull>(document);
        }
    }
}
