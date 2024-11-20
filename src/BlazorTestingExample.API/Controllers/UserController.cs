using BlazorTestingExample.Core.User;
using BlazorTestingExample.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorTestingExample.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService service) : ControllerBase
{
    [HttpPost]
    [Route("new")]
    public UserDto SubmitNewUser(UserDto user)
    {
        return service.AddUser(user);
    }
}