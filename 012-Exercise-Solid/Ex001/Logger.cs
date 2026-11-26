namespace Ex001;

public class Logger : ILogger
{
    private readonly IAppender[] appenders;

    public Logger(params IAppender[] appenders)
    {
        this.appenders = appenders;
    }

    public IReadOnlyCollection<IAppender> Appenders => appenders;

    public void Info(string dateTime, string message) => Log(dateTime, ReportLevel.Info, message);

    public void Warning(string dateTime, string message) => Log(dateTime, ReportLevel.Warning, message);

    public void Error(string dateTime, string message) => Log(dateTime, ReportLevel.Error, message);

    public void Critical(string dateTime, string message) => Log(dateTime, ReportLevel.Critical, message);

    public void Fatal(string dateTime, string message) => Log(dateTime, ReportLevel.Fatal, message);

    public void Log(string dateTime, ReportLevel level, string message)
    {
        foreach (var appender in appenders)
            appender.Append(dateTime, level, message);
    }
}
