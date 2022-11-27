using Shared.Models;

namespace Logic.Services
{
    public interface IDocumentService : IServiceBase
    {
        public Task<DocumentFull> GetByIdAsync(string documentId);
    }
}
