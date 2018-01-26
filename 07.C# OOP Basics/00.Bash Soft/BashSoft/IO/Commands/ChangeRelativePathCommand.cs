using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BashSoft.Exceptions;
namespace BashSoft.IO.Commands
{
    public class ChangeRelativePathCommand : Command
    {
        public ChangeRelativePathCommand(string input, string[] data, Tester junge, StudentsRepository repository, IOManager inputOutputManager):
            base(input,data,junge,repository,inputOutputManager)
        {
        }
        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string relPath = this.Data[1];
                this.InputOutputManager.ChangeCurrentDirectoryRelative(relPath);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
