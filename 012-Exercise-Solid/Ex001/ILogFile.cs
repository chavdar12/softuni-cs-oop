namespace Ex001;

public interface ILogFile
{
    int Size { get; }

    void Write(string message);
}
