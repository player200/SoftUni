﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
    public class InputReader
    {
        private const string endCommand = "quit";
        private CommandInterpreter interpreter;
        public InputReader(CommandInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }
        public void StartReadingCommands()
        {
            while (true)
            {
                OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
                string input = Console.ReadLine();
                input = input.Trim();
                if (input == endCommand)
                {
                    break;
                }
                this.interpreter.InterpredCommand(input);
            }
        }
    }
}
