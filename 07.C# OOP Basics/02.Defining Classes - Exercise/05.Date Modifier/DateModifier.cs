using System;
public class DateModifier
{
    public int DateDifferenceDays { get; set; }

    public void FindDifference(string dateOne, string dateTwo)
    {
        DateTime date1 = DateTime.Parse(dateOne);
        DateTime date2 = DateTime.Parse(dateTwo);

        double result = Math.Abs((date1 - date2).TotalDays);
        this.DateDifferenceDays = (int)result;
    }
}