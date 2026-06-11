namespace Automation.Core.Logging;

public class NullTestReporter : ITestReporter
{
    public void AddAttachment(string name, string contentType, string filePath)
    {
        // No-op reporter for projects without reporting integration.
    }
}