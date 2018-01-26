using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public delegate void JobDoneEventHandler(object sender, JobEventArgs e);
    static void Main()
    {
        JobsList jobs = new JobsList();
        List<BaseEmployee> emploees = new List<BaseEmployee>();
        string input;
        while ((input=Console.ReadLine()) != "End")
        {
            string[] tokens=input.Split();
            switch (tokens[0])
            {
                case "Job":
                    Job realJob = new Job(tokens[1], int.Parse(tokens[2]), emploees.FirstOrDefault(e => e.Name == tokens[3]));
                    realJob.JobDone += realJob.OnJobDone;
                    jobs.Add(realJob);
                    break;
                case "StandartEmployee":
                    emploees.Add(new StandartEmployee(tokens[1]));
                    break;
                case "PartTimeEmployee":
                    emploees.Add(new PartTimeEmployee(tokens[1]));
                    break;
                case "Pass":
                    foreach (var job in jobs)
                    {
                        job.Update();
                    }
                    break;
                case "Status":
                    foreach (var job in jobs)
                    {
                        if (!job.IsDone)
                        {
                            Console.WriteLine(job.ToString());
                        }
                    }
                    break;
            }
        }
    }
}