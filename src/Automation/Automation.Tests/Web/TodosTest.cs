using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Automation.Playwright.TestBase;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class TodosTest : WebTestBase
{
    [SetUp]
    public async Task SetUp()
    {
        await Page.GotoAsync("https://demo.playwright.dev/todomvc");
    }
        
    
    [Test]
    [Category("Smoke")]
    public async Task AddTask()
    {
        await Expect(Page.GetByRole(AriaRole.Heading)).ToContainTextAsync("todos");
        await Expect(Page.GetByText("Double-click to edit a todo")).ToBeVisibleAsync();
        await Expect(Page.GetByText("Created by Remo H. Jansen")).ToBeVisibleAsync();
        await Expect(Page.GetByText("Part of TodoMVC")).ToBeVisibleAsync();
        await Page.GetByRole(AriaRole.Textbox, new() { Name = "What needs to be done?" }).ClickAsync();
        await Page.GetByRole(AriaRole.Textbox, new() { Name = "What needs to be done?" }).FillAsync("prepare to interview");
        await Page.GetByRole(AriaRole.Textbox, new() { Name = "What needs to be done?" }).PressAsync("Enter");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Completed" }).ClickAsync();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Active" }).ClickAsync();
        await Expect(Page.GetByTestId("todo-title")).ToBeVisibleAsync();
        await Page.GetByRole(AriaRole.Link, new() { Name = "All" }).ClickAsync();
        await Page.GetByRole(AriaRole.Checkbox, new() { Name = "Toggle Todo" }).CheckAsync();
        await Expect(Page.GetByRole(AriaRole.Checkbox, new() { Name = "Toggle Todo" })).ToBeCheckedAsync();
        await Expect(Page.GetByTestId("todo-title")).ToBeVisibleAsync();
        await Expect(Page.GetByTestId("todo-title")).ToMatchAriaSnapshotAsync("- text: prepare to interview");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Active" }).ClickAsync();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Completed" }).ClickAsync();
        await Expect(Page.GetByTestId("todo-title")).ToBeVisibleAsync();
    }
}