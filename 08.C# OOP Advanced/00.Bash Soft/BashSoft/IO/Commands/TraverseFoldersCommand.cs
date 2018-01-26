namespace BashSoft.IO.Commands
{
    using BashSoft.Attributes;
    using Contracts;
    using Execptions;

    [Alias("ls")]
    public class TraverseFoldersCommand : Command
    {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public TraverseFoldersCommand(string input, string[] data) : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 1)
            {
                this.inputOutputManager.TraverseDirectory(0);
            }
            else
            {
                int depth;
                var success = int.TryParse(this.Data[1], out depth);
                if (success)
                {
                    this.inputOutputManager.TraverseDirectory(depth);
                }
                else
                {
                    throw new InvalidNumberParseException();
                }
            }
        }
    }
}
