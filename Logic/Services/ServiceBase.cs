using AutoMapper;
using Database.Repositories;
using Mergers;

namespace Logic.Services
{
    public class ServiceBase : ServiceBase<IRepositoryWrapper>, IServiceBase
    {
        public ServiceBase(IRepositoryWrapper repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public ServiceBase(IRepositoryWrapper repository, IMapper mapper, IMerger merger) : base(repository, mapper, merger)
        {
        }
    }
}
