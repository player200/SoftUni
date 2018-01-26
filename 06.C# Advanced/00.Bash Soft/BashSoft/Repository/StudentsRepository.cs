using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
namespace BashSoft
{
    public static class StudentsRepository
    {
        public static bool isDataInitialized = false;
        private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;
        public static void InitializedData(string fileName)
        {
            if (!isDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine("Reading data...");
                studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                ReadData(fileName);
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.DataAlreadyInitialisedException);
            }
        }
        private static void ReadData(string fileName)
        {
            string path = SessionData.currentPath + "\\" + fileName;
            if (File.Exists(path))
            {
                string pattern = @"([A-Z][a-zA-Z#+]*_[A-Z][a-z]{2}_\d{4})\s+([A-Z][a-z]{0,3}\d{2}_\d{2,4})\s+(\d+)";
                Regex rgx = new Regex(pattern);
                string[] allInputLines = File.ReadAllLines(path);
                for (int line = 0; line < allInputLines.Length; line++)
                {
                    if (!string.IsNullOrEmpty(allInputLines[line]) && rgx.IsMatch(allInputLines[line]))
                    {
                        Match currentMatch = rgx.Match(allInputLines[line]);
                        string courseName = currentMatch.Groups[1].Value;
                        string username = currentMatch.Groups[2].Value;
                        int studentOnTast;
                        bool hasParsedScore = int.TryParse(currentMatch.Groups[3].Value, out studentOnTast);
                        if (hasParsedScore && studentOnTast >= 0 && studentOnTast <= 100)
                        {
                            if (!studentsByCourse.ContainsKey(courseName))
                            {
                                studentsByCourse.Add(courseName, new Dictionary<string, List<int>> { { username, new List<int>() { studentOnTast } } });
                            }
                            if (!studentsByCourse[courseName].ContainsKey(username))
                            {
                                studentsByCourse[courseName].Add(username, new List<int>() { studentOnTast });
                            }
                            studentsByCourse[courseName][username].Add(studentOnTast);
                        }
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }
            isDataInitialized = true;
            OutputWriter.WriteMessageOnNewLine("Data read!");
        }
        private static bool IsQueryForCoursePossible(string courseName)
        {
            if (isDataInitialized)
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }
            if (studentsByCourse.ContainsKey(courseName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
            }
            return false;
        }
        private static bool IsQueryForStudentPossiblе(string courseName,string studentUserName)
        {
            if (IsQueryForCoursePossible(courseName)&&studentsByCourse[courseName].ContainsKey(studentUserName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
            }
            return false;
        }
        public static void GetStudentScoreFromCourses(string coursName,string username)
        {
            if (IsQueryForStudentPossiblе(coursName,username))
            {
                OutputWriter.PrintStudent(new KeyValuePair<string,List<int>>(username,studentsByCourse[coursName][username]));
            }
        }
        public static void GetAllStudentsFromCourses(string coursName)
        {
            if (IsQueryForCoursePossible(coursName))
            {
                OutputWriter.WriteMessageOnNewLine($"{coursName}");
                foreach (var studentMarkEntry in studentsByCourse[coursName])
                {
                    OutputWriter.PrintStudent(studentMarkEntry);
                }
            }
        }
        public static void FilterAndTake(string courseName, string givenFilter,int? studentsToTake=null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                studentsToTake = studentsByCourse[courseName].Count;
            }

            RepositoryFilters.FilterAndTake(studentsByCourse[courseName],givenFilter,studentsToTake.Value);
        }
        public static void OrderAndTake(string courseName,string comparison,int? studentsToTake=null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake==null)
                {
                    studentsToTake = studentsByCourse[courseName].Count;
                }

                RepositorySorters.OrderAndTake(studentsByCourse[courseName],comparison,studentsToTake.Value);
            }
        }
    }
}
