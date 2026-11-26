namespace Ex003;

public class ModifyPrice
{
    private readonly List<ICommand> commands = new();
    private ICommand command;

    public IReadOnlyCollection<ICommand> Commands => commands;

    public void SetCommand(ICommand command) => this.command = command;

    public void Invoke()
    {
        commands.Add(command);
        command.ExecuteAction();
    }
}
