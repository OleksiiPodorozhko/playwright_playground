namespace Automation.Core.Logging;

public interface ITestReporter
{
    void AddAttachment(string name, string contentType, string filePath);
}