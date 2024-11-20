using BlazorTestingExample.Core.Clients;
using BlazorTestingExample.Core.Common;
using BlazorTestingExample.Core.User;
using BlazorTestingExample.Shared.Models;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorTestingExample.Core.Config;

public static class DependencyRegister
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddUserServices();
        services.AddCommonServices();
        services.AddClientServices();
        
        return services;
    }
}