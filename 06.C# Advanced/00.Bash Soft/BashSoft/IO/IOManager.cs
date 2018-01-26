using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace BashSoft
{
    public static class IOManager
    {
        public static void TraverseDirectory(int depth)
        {
            OutputWriter.WriteEmptyLine();
            int initialIdentator = SessionData.currentPath.Split('\\').Length;
            Queue<string> subFolder = new Queue<string>();
            subFolder.Enqueue(SessionData.currentPath);

            while (subFolder.Count!=0)
            {
                string currentPath = subFolder.Dequeue();
                int indentation = currentPath.Split('\\').Length - initialIdentator;
                if (depth - indentation < 0)
                {
                    break;
                }
                OutputWriter.WriteMessageOnNewLine(string.Format("{0}{1}", new string('-', indentation), currentPath));

                try
                {
                    foreach (var file in Directory.GetFiles(currentPath))
                    {
                        int indexOfLastSlash = file.LastIndexOf("\\");
                        string fileName = file.Substring(indexOfLastSlash);
                        OutputWriter.WriteMessageOnNewLine(new string('-', indexOfLastSlash) + fileName);
                    }

                    foreach (var subDir in Directory.GetDirectories(currentPath))
                    {
                        subFolder.Enqueue(subDir);
                    }
                }
                catch (UnauthorizedAccessException)
                {

                    OutputWriter.DisplayException(ExceptionMessages.UnauthorizedAccessExceptionMessage);
                }
                
            }
        }
        public static void CreateDirectoryInCurrentFolder(string name)
        {
            string path= Directory.GetCurrentDirectory()+"\\"+name;
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (ArgumentException)
            {
                OutputWriter.DisplayException(ExceptionMessages.ForbiddenSymbolsContainedInName);
            }
            
        }
        public static void ChangeCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath=="..")
            {
                try
                {
                    string currentPath = SessionData.currentPath;
                    int indexOfLastSlash = currentPath.LastIndexOf("\\");
                    string newPath = currentPath.Substring(0, indexOfLastSlash);
                    SessionData.currentPath = newPath;
                }
                catch (ArgumentOutOfRangeException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnauthorizedAccessExceptionMessage);
                }
            }
            else
            {
                string currentPath = SessionData.currentPath;
                currentPath += "\\" + relativePath;
                ChangeCurrentDirectoryAbsolute(currentPath);
            }
        }
        public static void ChangeCurrentDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
                return;
            }
            SessionData.currentPath = absolutePath;
        }
    }
}
