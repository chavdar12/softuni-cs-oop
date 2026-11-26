namespace Ex001;

public abstract class Appender : IAppender
{
    private readonly ILayout layout;

    protected Appender(ILayout layout)
    {
        this.layout = layout;
    }

    public ReportLevel ReportLevel { get; set; }

    public int MessagesAppended { get; private set; }

    public void Append(string dateTime, ReportLevel level, string message)
    {
        if (level < ReportLevel)
            return;

        Write(layout.Format(dateTime, level, message));
        MessagesAppended++;
    }

    protected abstract void Write(string formatted);

    public override string ToString()
    {
        return $"Appender type: {GetType().Name}, Layout type: {layout.GetType().Name}, "
            + $"Report level: {ReportLevel.ToString().ToUpper()}, Messages appended: {MessagesAppended}";
    }
}
