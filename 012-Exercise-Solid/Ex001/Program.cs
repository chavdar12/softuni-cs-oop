using Ex001;

var appenders = new IAppender[int.Parse(Console.ReadLine()!)];

for (var i = 0; i < appenders.Length; i++)
{
    var parts = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries);

    ILayout layout = parts[1] switch
    {
        nameof(SimpleLayout) => new SimpleLayout(),
        nameof(XmlLayout) => new XmlLayout(),
        _ => throw new ArgumentException($"Unknown layout {parts[1]}"),
    };

    IAppender appender = parts[0] switch
    {
        nameof(ConsoleAppender) => new ConsoleAppender(layout),
        nameof(FileAppender) => new FileAppender(layout, new LogFile()),
        _ => throw new ArgumentException($"Unknown appender {parts[0]}"),
    };

    if (parts.Length > 2)
        appender.ReportLevel = Enum.Parse<ReportLevel>(parts[2], true);

    appenders[i] = appender;
}

var logger = new Logger(appenders);

string line;
while ((line = Console.ReadLine()) != "END")
{
    var parts = line!.Split('|');
    logger.Log(parts[1], Enum.Parse<ReportLevel>(parts[0], true), parts[2]);
}

Console.WriteLine("Logger info");
foreach (var appender in appenders)
    Console.WriteLine(appender);
