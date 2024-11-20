using BlazorTestingExample.Core.Clients.DB;
using BlazorTestingExample.Core.Common;
using BlazorTestingExample.Core.Common.Helpers;
using BlazorTestingExample.Shared.Models;

namespace BlazorTestingExample.Core.User;

public interface IUserRepository
{
    void AddNewUser(UserDto user);
}

public class UserRepository(IMapper<UserDto, User> userMapper,
                            BlazorTestingExampleDbContext dbContext): IUserRepository
{
    public void AddNewUser(UserDto user)
    {
        var dbUser = userMapper.Map(user)!;
        dbContext.Users.Add(dbUser);
        dbContext.SaveChanges();
    }
}