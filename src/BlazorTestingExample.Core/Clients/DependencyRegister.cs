using BlazorTestingExample.Core.Clients.DB;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorTestingExample.Core.Clients;

public static class DependencyRegister
{
    public static IServiceCollection AddClientServices(this IServiceCollection services)
    {        
        services.AddScoped<BlazorTestingExampleDbContext>();
        
        return services;
    }
}