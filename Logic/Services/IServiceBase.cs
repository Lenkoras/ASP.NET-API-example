using Database.Repositories;

namespace Logic.Services
{
    public interface IServiceBase : IServiceBase<IRepositoryWrapper>
    {
    }
}
