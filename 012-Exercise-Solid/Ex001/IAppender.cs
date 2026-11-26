namespace Ex001;

public interface IAppender
{
    ReportLevel ReportLevel { get; set; }

    int MessagesAppended { get; }

    void Append(string dateTime, ReportLevel level, string message);
}
