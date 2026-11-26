namespace Ex001;

public class FileAppender : Appender
{
    private readonly ILogFile file;

    public FileAppender(ILayout layout, ILogFile file)
        : base(layout)
    {
        this.file = file;
    }

    protected override void Write(string formatted)
    {
        file.Write(formatted);
    }

    public override string ToString()
    {
        return $"{base.ToString()}, File size: {file.Size}";
    }
}
