using BlazorTestingExample.Core.Common.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorTestingExample.Core.Common;

public static class DependencyRegister
{
    public static IServiceCollection AddCommonServices(this IServiceCollection services)
    {
        services.AddTransient<IGuidHelper, GuidHelper>();
        
        return services;
    }
}