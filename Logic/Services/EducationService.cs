using AutoMapper;
using Database.Models;
using Database.Repositories;
using Shared.Models;

namespace Logic.Services
{
    public class EducationService : ServiceBase, IEducationService
    {
        public IRepository<Education> Repository => RepositoryWrapper.Educations;

        public EducationService(IRepositoryWrapper repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<EducationFull?> GetByIdAsync(string educationId) =>
            Map<EducationFull>(await Repository.FindAsync(educationId));
    }
}
