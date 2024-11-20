using BlazorTestingExample.Wasm.Clients;

namespace BlazorTestingExample.Wasm.Config;

public static class DependencyRegister
{
    public static IServiceCollection AddWasmServices(this IServiceCollection services)
    {
        services.AddScoped<IMyApiClient, MyApiClient>();
        
        return services;
    }
}