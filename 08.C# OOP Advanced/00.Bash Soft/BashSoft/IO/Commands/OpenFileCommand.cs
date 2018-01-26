﻿namespace BashSoft.IO.Commands
{
    using System.Diagnostics;
    using Attributes;
    using Execptions;

    [Alias("open")]
    public class OpenFileCommand : Command
    {
        public OpenFileCommand(string input, string[] data) : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            var filename = this.Data[1];
            Process.Start(SessionData.CurrentPath + "\\" + filename);
        }
    }
}
