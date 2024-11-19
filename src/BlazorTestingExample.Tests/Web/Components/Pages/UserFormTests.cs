using AngleSharp.Dom;
using BlazorTestingExample.Web.Components.Pages;
using Bunit;
using FluentAssertions;

namespace BlazorTestingExample.Tests.Web.Components.Pages;

public class UserFormTests : TestContext
{
    [Fact]
    public void Submit_ShouldShowSubmittedMessage_WhenFormIsValid()
    {
        var cut = RenderComponent<UserForm>();
        var firstName = "John";
        var lastName = "Doe";
        var expected = $"Submitted: {firstName} {lastName}";

        cut.Find("input[placeholder='First Name']").Change(firstName);
        cut.Find("input[placeholder='Last Name']").Change(lastName);
        cut.Find("button[type='submit']").Click();

        var pTags = cut.FindAll("p").ToList();
        var pTag = pTags.FirstOrDefault(p => p.InnerHtml == expected);
        pTag.Should().NotBeNull();
        //pTag!.IsVisible().Should().BeTrue();
        cut.Markup.Should().Contain(expected);
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
