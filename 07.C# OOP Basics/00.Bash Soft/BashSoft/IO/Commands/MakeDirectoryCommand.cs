using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BashSoft.Exceptions;
namespace BashSoft.IO.Commands
{
    public class MakeDirectoryCommand : Command
    {
        public MakeDirectoryCommand(string input, string[] data, Tester junge, StudentsRepository repository, IOManager inputOutputManager):
            base(input,data,junge,repository,inputOutputManager)
        {
        }
        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string folderName = this.Data[1];
                this.InputOutputManager.CreateDirectoryInCurrentFolder(folderName);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
