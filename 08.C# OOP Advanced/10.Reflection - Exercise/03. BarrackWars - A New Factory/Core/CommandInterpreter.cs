using System;
using System.Linq;
using System.Reflection;
using System.Globalization;
public class CommandInterpreter : ICommandInterpreter
{
    private const string CommandSuffix = "Command";
    private IRepository repository;
    private IUnitFactory unitFactory;
    public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
    {
        this.repository = repository;
        this.unitFactory = unitFactory;
    }
    public IExecutable InterpretCommand(string[] data, string commandName)
    {
        string commandCompleteName =
            CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName) + CommandSuffix;
        Type commandType = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == commandCompleteName);
        object[] commandParams =
        {
                data
        };
        if (commandType == null)
        {
            throw new InvalidOperationException("Invalid command!");
        }
        IExecutable currentCommand= (IExecutable)Activator.CreateInstance(commandType, commandParams);
        currentCommand = this.InjectDependancy(currentCommand);
        return currentCommand;
    }
    private IExecutable InjectDependancy(IExecutable currentCommand)
    {
        FieldInfo[] fields = currentCommand.GetType()
            .GetFields(BindingFlags.Instance|BindingFlags.NonPublic)
            .Where(f=>f.GetCustomAttribute<InjectAttribute>()!=null)
            .ToArray();
        FieldInfo[] interpreterFields = this.GetType().GetFields(BindingFlags.Instance|BindingFlags.NonPublic);
        foreach (FieldInfo field in fields)
        {
            field.SetValue(currentCommand, interpreterFields
                .First(f=>f.FieldType==field.FieldType)
                .GetValue(this));
        }
        return currentCommand;
    }
}