public class RetireCommand : Command
{
    [Inject]
    private IRepository repository;
    public RetireCommand(string[] data) : base(data)
    {
    }
    public override string Execute()
    {
        this.repository.RemoveUnit(this.Data[1]);
        return $"{this.Data[1]} retired!";
    }
}