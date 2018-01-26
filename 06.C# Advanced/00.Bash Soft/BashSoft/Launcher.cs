using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BashSoft
{
    class Launcher
    {
        static void Main()
        {
            //1-
            //IOManager.TraverseDirectory(@"..\..\00.Bash Soft");

            //2-
            //use data.txt for testing it:
            //StudentsRepository.InitializedData();
            //StudentsRepository.GetAllStudentsFromCourses("Unity");
            //StudentsRepository.GetStudentScoreFromCourses("Unity", "Ivan");

            //3-
            //Tester.CompareContent(@"..\..\test1.txt", @"..\..\test2.txt");
            //Tester.CompareContent(@"..\..\test2.txt", @"..\..\test3.txt");
            //IOManager.CreateDirectoryInCurrentFolder("pesho");
            //IOManager.ChangeCurrentDirectoryRelative("pesho");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.TraverseDirectory(900);

            //4-
            //IOManager.ChangeCurrentDirectoryAbsolute(@"C:\Windows");
            //IOManager.TraverseDirectory(20);
            //IOManager.CreateDirectoryInCurrentFolder("*2");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");

            //5-8
            InputReader.StartReadingCommands();
        }
    }
}
