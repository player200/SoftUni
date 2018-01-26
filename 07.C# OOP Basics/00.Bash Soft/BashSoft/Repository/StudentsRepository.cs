using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using BashSoft.Models;
using BashSoft.Exceptions;
namespace BashSoft
{
    public class StudentsRepository
    {
        private bool isDataInitialized;
        private RepositoryFilter filter;
        private RepositorySorter sorter;
        private Dictionary<string, Course> courses;
        private Dictionary<string, Student> students;
        public StudentsRepository(RepositorySorter sorter, RepositoryFilter filter)
        {
            this.filter = filter;
            this.sorter = sorter;
        }
        public void LoadData(string fileName)
        {
            if (this.isDataInitialized)
            {
                throw new InvalidOperationException(ExceptionMessages.DataAlreadyInitialisedException);
            }

            OutputWriter.WriteMessageOnNewLine("Reading data...");
            this.students = new Dictionary<string, Student>();
            this.courses = new Dictionary<string, Course>();
            ReadData(fileName);
        }
        private void ReadData(string fileName)
        {
            string path = SessionData.currentPath + "\\" + fileName;
            if (File.Exists(path))
            {
                string pattern = @"([A-Z][a-zA-Z#\++]*_[A-Z][a-z]{2}_\d{4})\s+([A-Za-z]+\d{2}_\d{2,4})\s([\s0-9]+)";
                Regex rgx = new Regex(pattern);
                string[] allInputLines = File.ReadAllLines(path);
                for (int line = 0; line < allInputLines.Length; line++)
                {
                    if (!string.IsNullOrEmpty(allInputLines[line]) && rgx.IsMatch(allInputLines[line]))
                    {
                        Match currentMatch = rgx.Match(allInputLines[line]);
                        string courseName = currentMatch.Groups[1].Value;
                        string username = currentMatch.Groups[2].Value;
                        string scoresStr = currentMatch.Groups[3].Value;
                        try
                        {
                            int[] scores = scoresStr.Split(new char[] {' ' },StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();
                            if (scores.Any(x=>x>100 || x<0))
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidScore);
                            }
                            if (scores.Length>Course.NumberOfTasksOnExam)
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidNumberOfScores);
                                continue;
                            }
                            if (!this.students.ContainsKey(username))
                            {
                                this.students.Add(username,new Student(username));
                            }
                            if (!this.courses.ContainsKey(courseName))
                            {
                                this.courses.Add(courseName,new Course(courseName));
                            }
                            Course course = this.courses[courseName];
                            Student student = this.students[username];

                            student.EnrollInCourse(course);
                            student.SetMarkOnCourse(courseName, scores);

                            course.EnrollStudent(student);
                        }
                        catch (FormatException fex)
                        {
                            OutputWriter.DisplayException(fex.Message + $"at line: {line}");
                        }
                    }
                }
            }
            else
            {
                throw new InvalidPathException();
            }
            isDataInitialized = true;
            OutputWriter.WriteMessageOnNewLine("Data read!");
        }
        private bool IsQueryForCoursePossible(string courseName)
        {
            if (isDataInitialized)
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }
            if (this.courses.ContainsKey(courseName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
            }
            return false;
        }
        private bool IsQueryForStudentPossiblе(string courseName,string studentUserName)
        {
            if (IsQueryForCoursePossible(courseName)&&this.courses[courseName].StudentsByName.ContainsKey(studentUserName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
            }
            return false;
        }
        public void GetStudentScoreFromCourses(string coursName,string username)
        {
            if (IsQueryForStudentPossiblе(coursName,username))
            {
                OutputWriter.PrintStudent(new KeyValuePair<string,double>(username,
                    this.courses[coursName].StudentsByName[username].MarksByCourseName[coursName]));
            }
        }
        public void GetAllStudentsFromCourses(string coursName)
        {
            if (IsQueryForCoursePossible(coursName))
            {
                OutputWriter.WriteMessageOnNewLine($"{coursName}");
                foreach (var studentMarkEntry in this.courses[coursName].StudentsByName)
                {
                    this.GetStudentScoreFromCourses(coursName,studentMarkEntry.Key);
                }
            }
        }
        public void FilterAndTake(string courseName, string givenFilter,int? studentsToTake=null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                studentsToTake = this.courses[courseName].StudentsByName.Count;
            }
            Dictionary<string, double> marks = this.courses[courseName].StudentsByName
                .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);
            this.filter.FilterAndTake(marks,givenFilter,studentsToTake.Value);
        }
        public void OrderAndTake(string courseName,string comparison,int? studentsToTake=null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake==null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }
                Dictionary<string, double> marks = this.courses[courseName].StudentsByName
                    .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);
                this.sorter.OrderAndTake(marks,comparison,studentsToTake.Value);
            }
        }
        public void UnloadData()
        {
            if (!this.isDataInitialized)
            {
                throw new ArgumentException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            this.students = null;
            this.courses = null;
            this.isDataInitialized = false;
        }
    }
}
