using AngleSharp.Dom;
using BlazorTestingExample.Core.User;
using BlazorTestingExample.Shared.Models;
using BlazorTestingExample.Web.Components.Pages;
using Bunit;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace BlazorTestingExample.Tests.Web.Components.Pages;

public class UserFormTests : TestContext
{
    private readonly IUserService userService = Substitute.For<IUserService>();
    
    public UserFormTests()
    {
        Services.AddTransient<IUserService>(_ => userService);
    }
    
    [Fact]
    public void Submit_ShouldShowSubmittedMessage_WhenFormIsValid()
    {
        var cut = RenderComponent<UserForm>();
        var firstName = "John";
        var lastName = "Doe";
        var newUser = new UserDto
        {
            Id = Guid.NewGuid(),
            FirstName = "bob",
            LastName = "bobby"
        };
        var expected = $"Submitted: {newUser.FirstName} {newUser.LastName} ({newUser.Id})";
        userService
            .AddUser(Arg.Is<UserDto>(u => u.FirstName == firstName && u.LastName == lastName))
            .Returns(newUser);

        cut.Find("input[placeholder='First Name']").Change(firstName);
        cut.Find("input[placeholder='Last Name']").Change(lastName);
        cut.Find("button[type='submit']").Click();

        var pTags = cut.FindAll("p").ToList();
        var pTag = pTags.FirstOrDefault(p => p.InnerHtml == expected);
        pTag.Should().NotBeNull();
    }

    [Fact]
    public void Submit_ShouldShowAllErrorMessages_WhenFormIsEmpty()
    {
        var cut = RenderComponent<UserForm>();

        cut.Find("button[type='submit']").Click();

        var errors = cut.FindAll(".validation-message");
        errors.Should().Contain(e => e.TextContent == "First Name is required.");
        errors.Should().Contain(e => e.TextContent == "Last Name is required.");
    }
}
