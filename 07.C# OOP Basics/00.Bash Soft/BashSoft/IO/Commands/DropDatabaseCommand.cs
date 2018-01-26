using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BashSoft.Exceptions;
namespace BashSoft.IO.Commands
{
    public class DropDatabaseCommand : Command
    {
        public DropDatabaseCommand(string input, string[] data, Tester junge, StudentsRepository repository, IOManager inputOutputManager):
            base(input,data,junge,repository,inputOutputManager)
        {
        }
        public override void Execute()
        {
            if (this.Data.Length != 1)
            {
                throw new InvalidCommandException(this.Input);
            }

            this.Repository.UnloadData();
            OutputWriter.WriteMessageOnNewLine("Database dropped!");
        }
    }
}
