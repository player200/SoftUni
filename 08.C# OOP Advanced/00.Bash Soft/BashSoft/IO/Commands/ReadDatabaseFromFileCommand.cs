namespace BashSoft.IO.Commands
{
    using BashSoft.Attributes;
    using Contracts;
    using Execptions;

    [Alias("readDb")]
    public class ReadDatabaseFromFileCommand : Command
    {
        [Inject]
        private IDatabase repository;

        public ReadDatabaseFromFileCommand(string input, string[] data) : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            var databasePath = this.Data[1];
            this.repository.LoadData(databasePath);
        }
    }
}
