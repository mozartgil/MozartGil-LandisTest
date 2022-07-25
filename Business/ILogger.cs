namespace IloogerBusiness;

 /// <summary>
/// Logs Interface
/// </summary>
public interface ILogger
{
    void Log(LogLevel logLevel, string message);
}

public enum LogLevel
{
    Information,
    Error
}