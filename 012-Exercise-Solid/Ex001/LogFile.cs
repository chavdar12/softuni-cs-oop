using System.Text;

namespace Ex001;

public class LogFile : ILogFile
{
    private readonly StringBuilder content = new();

    public int Size => content.ToString().Where(char.IsAsciiLetter).Sum(c => c);

    public void Write(string message)
    {
        content.AppendLine(message);
    }
}
