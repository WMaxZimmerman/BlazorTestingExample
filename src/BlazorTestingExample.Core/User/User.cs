using System.ComponentModel.DataAnnotations;

namespace BlazorTestingExample.Core.User;

public record User
{
    [Key]
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}