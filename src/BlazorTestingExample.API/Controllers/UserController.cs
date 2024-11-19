using BlazorTestingExample.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorTestingExample.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    [HttpPost]
    public bool SubmitNewUser(User user)
    {
        return user.FirstName.Length > 0 && user.LastName.Length > 0;
    }
}