using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Automation.Playwright.TestBase;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class PlaywrightTest : WebTestBase
{
    [SetUp]
    public async Task SetUp()
    {
        await Page.GotoAsync("https://playwright.dev");
    }
        
    
    [Test]
    [Category("Smoke")]
    public async Task HasTitle()
    {
        await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));
        var buttonGetStarted = Page.GetByRole(AriaRole.Link, new() { Name = "Get started" });
        await Expect(buttonGetStarted).ToContainTextAsync("Get starteddd");
        await Expect(buttonGetStarted).ToHaveCSSAsync("background-image", "linear-gradient(135deg, rgb(69, 186, 75) 0%, rgb(61, 168, 67) 100%)");
        await buttonGetStarted.ClickAsync();
        // await Page.PauseAsync();
        await Expect(Page).ToHaveTitleAsync(new Regex("Installation \\| Playwright"));
    }

    [Test]
    public async Task GetStartedLink()
    {
        // Click the get started link.
        await Page.GetByRole(AriaRole.Link, new() { Name = "Get started" }).ClickAsync();

        // Expects page to have a heading with the name of Installation.
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Installation" })).ToBeVisibleAsync();
    } 
}