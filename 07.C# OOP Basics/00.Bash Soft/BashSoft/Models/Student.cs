using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BashSoft.Exceptions;
namespace BashSoft.Models
{
    public class Student
    {
        private string userName;
        private Dictionary<string,Course> enrolledCourses;
        private Dictionary<string ,double> marksByCourseName;
        public Student(string userName)
        {
            this.Username = userName;
            this.enrolledCourses = new Dictionary<string, Course>();
            this.marksByCourseName = new Dictionary<string, double>();
        }
        public string Username
        {
            get { return this.userName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }
                this.userName = value;
            }
        }
        public void EnrollInCourse(Course course)
        {
            if (this.enrolledCourses.ContainsKey(course.Name))
            {
                throw new DuplicateEntryInStructureException(this.userName, course.Name);
            }
            this.enrolledCourses.Add(course.Name,course);
        }
        public void SetMarkOnCourse(string courseName,params int[] scores)
        {
            if (!this.enrolledCourses.ContainsKey(courseName))
            {
                throw new CourseNotFoundException();
            }

            if (scores.Length>Course.NumberOfTasksOnExam)
            {
                throw new ArgumentException(ExceptionMessages.InvalidNumberOfScores);
            }

            this.marksByCourseName.Add(courseName,CalculateMark(scores));
        }
        public IReadOnlyDictionary<string, Course> EnrolledCourses
        {
            get
            {
                return enrolledCourses;
            }
        }
        public IReadOnlyDictionary<string, double> MarksByCourseName
        {
            get
            {
                return marksByCourseName;
            }
        }
        private double CalculateMark(int[] scores)
        {
            double parcentageOfSolvedExam = scores.Sum() / (double)(Course.NumberOfTasksOnExam * Course.MaxScoreOnExamTask);
            double mark = parcentageOfSolvedExam * 4 + 2;
            return mark;
        }
    }
}
