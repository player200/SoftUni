namespace BashSoft.IO.Commands
{
    using BashSoft.Attributes;
    using Contracts;
    using Execptions;

    [Alias("dropdb")]
    public class DropDbCommand : Command
    {
        [Inject]
        private IDatabase repository;

        public DropDbCommand(string input, string[] data) : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 1)
            {
                throw new InvalidCommandException(this.Input);
            }

            this.repository.UnloadData();
            OutputWriter.WriteMessageOnNewLine("Database dropped!");
        }
    }
}
