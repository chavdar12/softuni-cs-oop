namespace Ex001;

public class SimpleLayout : ILayout
{
    public string Format(string dateTime, ReportLevel level, string message)
    {
        return $"{dateTime} - {level.ToString().ToUpper()} - {message}";
    }
}
