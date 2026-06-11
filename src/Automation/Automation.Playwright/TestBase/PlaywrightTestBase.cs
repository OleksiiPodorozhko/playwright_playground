using Automation.Core.Logging;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace Automation.Playwright.TestBase;

public abstract class PlaywrightTestBase : PageTest
{
    [SetUp]
    public async Task Setup()
    {
        await Context.Tracing.StartAsync(new()
        {
            Title = $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}",
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });
    }

    [TearDown]
    public async Task TearDown()
    {
        var tracePath = Path.Combine(
            TestContext.CurrentContext.WorkDirectory,
            "test-results",
            $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}.{DateTime.Now:yy-MM-dd-HH-mm-ss}.zip"
        );

        await Context.Tracing.StopAsync(new()
        {
            Path = tracePath
        });

        await OnTraceCreatedAsync(tracePath);
    }

    // protected Task TestStep(string name, Func<Task> action)
    // {
    //     
    // }

    protected virtual Task OnTraceCreatedAsync(string tracePath)
    {
        return Task.CompletedTask;
    }
}