class Program
{
    static void Main()
    {
        IRepository repository = new UnitRepository();
        IUnitFactory unitFactory = new UnitFactory();
        ICommandInterpreter commandInterpreter = new CommandInterpreter(repository, unitFactory);
        IRunnable engine = new Engine(commandInterpreter);
        engine.Run();
    }
}