using Microsoft.Extensions.DependencyInjection;
using ProxyPatternCaching.Infrastructure.Repositories;
using ProxyPatternCaching.Infrastructure.Repositories.Interfaces;

namespace ProxyPatternCaching.Infrastructure;

public static class ServiceRegistration
{
    public static void AddRepositoryRegistration(this IServiceCollection services)
    {
        services.AddScoped<BookRepository>();
        services.AddScoped<IBookRepository, CachedBookRepository>();
    }
}