using System.ComponentModel.DataAnnotations;

namespace BlazorTestingExample.Shared.Models;

public record User
{
    [Required(ErrorMessage = "First Name is required.")]
    public string FirstName { get; set; } = "";

    [Required(ErrorMessage = "Last Name is required.")]
    public string LastName { get; set; } = "";
}