using Allure.Net.Commons;
using Allure.NUnit;
using Automation.Playwright.TestBase;

namespace PlaywrightTests;

[AllureNUnit]
public abstract class WebTestBase : PlaywrightTestBase
{
    protected override Task OnTraceCreatedAsync(string tracePath)
    {
        if (File.Exists(tracePath))
        {
            AllureApi.AddAttachment(
                "Playwright trace",
                "application/zip",
                tracePath
            );
        }

        return Task.CompletedTask;
    }
}