namespace BashSoft.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IStudent : IComparable<IStudent>
    {
        IReadOnlyDictionary<string, ICourse> EnrolledCourses { get; }

        IReadOnlyDictionary<string, double> MarksByCourseName { get; }

        string Username { get; }

        void EnrollInCourse(ICourse course);

        void SetMarkOnCourse(string courseName, params int[] scores);
    }
}