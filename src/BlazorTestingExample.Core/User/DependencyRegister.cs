using BlazorTestingExample.Core.Common;
using BlazorTestingExample.Shared.Models;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorTestingExample.Core.User;

public static class DependencyRegister
{
    public static IServiceCollection AddUserServices(this IServiceCollection services)
    {
        services.AddTransient<IMapper<UserDto, User>, Mapper<UserDto, User>>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUserService, UserService>();
        
        return services;
    }
}