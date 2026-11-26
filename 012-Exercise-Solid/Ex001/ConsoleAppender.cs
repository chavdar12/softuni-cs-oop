namespace Ex001;

public class ConsoleAppender : Appender
{
    public ConsoleAppender(ILayout layout)
        : base(layout) { }

    protected override void Write(string formatted)
    {
        Console.WriteLine(formatted);
    }
}
