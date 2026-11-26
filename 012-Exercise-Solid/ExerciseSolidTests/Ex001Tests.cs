using Ex001;

namespace ExerciseSolidTests;

public class Ex001Tests
{
    private const string Time = "3/31/2015 5:33:07 PM";

    [Test]
    public void SimpleLayoutFormatsDateLevelAndMessage()
    {
        Assert.That(
            new SimpleLayout().Format(Time, ReportLevel.Error, "Error parsing request"),
            Is.EqualTo("3/31/2015 5:33:07 PM - ERROR - Error parsing request")
        );
    }

    [Test]
    public void LogFileSizeSumsOnlyLetterCodes()
    {
        var file = new LogFile();
        new FileAppender(new SimpleLayout(), file).Append(Time, ReportLevel.Error, "Error parsing request");

        Assert.That(file.Size, Is.EqualTo(2606));
    }

    [Test]
    public void XmlLayoutAddsTagLettersToFileSize()
    {
        var file = new LogFile();
        new FileAppender(new XmlLayout(), file).Append(Time, ReportLevel.Error, "Error parsing request");

        Assert.That(file.Size, Is.EqualTo(6632));
    }

    [Test]
    public void AppenderSkipsMessagesBelowItsThreshold()
    {
        var file = new LogFile();
        var appender = new FileAppender(new SimpleLayout(), file) { ReportLevel = ReportLevel.Error };
        var logger = new Logger(appender);

        logger.Info(Time, "Everything seems fine");
        logger.Warning(Time, "Ping is too high");
        logger.Error(Time, "Error parsing request");
        logger.Fatal(Time, "mscorlib.dll does not respond");

        Assert.That(appender.MessagesAppended, Is.EqualTo(2));
    }

    [Test]
    public void LoggerAcceptsCustomLayouts()
    {
        var file = new LogFile();
        new Logger(new FileAppender(new UpperLayout(), file)).Info(Time, "abc");

        Assert.That(file.Size, Is.EqualTo('A' + 'B' + 'C'));
    }

    [Test]
    public void ProgramInterpretsCommands()
    {
        const string input = """
            2
            ConsoleAppender SimpleLayout CRITICAL
            FileAppender XmlLayout
            INFO|3/26/2015 2:08:11 PM|Everything seems fine
            WARNING|3/26/2015 2:22:13 PM|Warning: ping is too high - disconnect imminent
            ERROR|3/26/2015 2:32:44 PM|Error parsing request
            CRITICAL|3/26/2015 2:38:01 PM|No connection string found in App.config
            FATAL|3/26/2015 2:39:19 PM|mscorlib.dll does not respond
            END
            """;

        Assert.That(
            ConsoleRunner.Run(typeof(Logger).Assembly, input),
            Is.EqualTo(
                """
                3/26/2015 2:38:01 PM - CRITICAL - No connection string found in App.config
                3/26/2015 2:39:19 PM - FATAL - mscorlib.dll does not respond
                Logger info
                Appender type: ConsoleAppender, Layout type: SimpleLayout, Report level: CRITICAL, Messages appended: 2
                Appender type: FileAppender, Layout type: XmlLayout, Report level: INFO, Messages appended: 5, File size: 37526
                """
            )
        );
    }

    private class UpperLayout : ILayout
    {
        public string Format(string dateTime, ReportLevel level, string message) => message.ToUpper();
    }
}
