namespace Ex001;

public class XmlLayout : ILayout
{
    public string Format(string dateTime, ReportLevel level, string message)
    {
        return string.Join(
            Environment.NewLine,
            "<log>",
            $"\t<date>{dateTime}</date>",
            $"\t<level>{level.ToString().ToUpper()}</level>",
            $"\t<message>{message}</message>",
            "</log>"
        );
    }
}
