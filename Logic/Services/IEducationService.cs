using Shared.Models;

namespace Logic.Services
{
    public interface IEducationService : IServiceBase
    {
        Task<EducationFull?> GetByIdAsync(string educationId);
    }
}