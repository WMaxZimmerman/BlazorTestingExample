using BlazorTestingExample.Core.Common.Helpers;
using BlazorTestingExample.Shared.Models;

namespace BlazorTestingExample.Core.User;

public interface IUserService
{
    UserDto AddUser(UserDto user);
}

public class UserService(IUserRepository userRepository, IGuidHelper guidHelper): IUserService
{
    public UserDto AddUser(UserDto user)
    {
        var newId = guidHelper.New();
        var newUser = user with { Id = newId };
        userRepository.AddNewUser(newUser);
        return newUser;
    }
}