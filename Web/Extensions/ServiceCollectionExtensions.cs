using Database.Mapping;
using Database.Repositories;

namespace Web.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositoryWrapper(this IServiceCollection services) =>
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

        public static IServiceCollection AddAutoMapper(this IServiceCollection services) =>
            services.AddAutoMapper<MapperProfile>();
    }
}
