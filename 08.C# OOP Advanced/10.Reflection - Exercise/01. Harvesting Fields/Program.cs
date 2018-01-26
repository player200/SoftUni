using System;
class Program
{
    static void Main()
    {
        Collector collector = new Collector();
        string inpuLine;
        while ((inpuLine = Console.ReadLine()) != "HARVEST")
        {
            string result;
            switch (inpuLine)
            {
                case "private":
                    result = collector.GetAllPriviteFields("HarvestingFields");
                    Console.WriteLine(result);
                    break;
                case "protected":
                    result = collector.GetAllProtectedFields("HarvestingFields");
                    Console.WriteLine(result);
                    break;
                case "public":
                    result = collector.GetAllPublicFields("HarvestingFields");
                    Console.WriteLine(result);
                    break;
                case "all":
                    result = collector.GetAllFields("HarvestingFields");
                    Console.WriteLine(result);
                    break;
            }
        }
    }
}