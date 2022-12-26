using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ProxyPatternCaching.Application.Mapper;
using ProxyPatternCaching.Application.Services;
using ProxyPatternCaching.Application.Services.Interfaces;

namespace ProxyPatternCaching.Application;

public static class ServiceRegistration
{
    public static void AddServiceRegistration(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
    }
    
    public static void AddAutoMapperRegistration(this IServiceCollection services)
    {
        var mappingConfiguration = new MapperConfiguration(conf => { conf.AddProfile(new GeneralMapping()); });

        var mapper = mappingConfiguration.CreateMapper();
        services.AddSingleton(mapper);
    }

}