namespace _02.SliceFile
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            //I delete video file because it was too big
            string sourceFile = Console.ReadLine();
            string destinationPath = Console.ReadLine();
            int pieces = int.Parse(Console.ReadLine());

            Task
                .Run((() =>
                {
                    Slice(sourceFile, destinationPath, pieces);
                }))
            .GetAwaiter()
            .GetResult();
        }

        private static void Slice(string sourceFile, string destinationPath, int pieces)
        {
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            using (var source = new FileStream(sourceFile, FileMode.Open))
            {
                long parthLengt = source.Length / pieces + 1;
                long currentByte = 0;

                FileInfo fielInfo = new FileInfo(sourceFile);
                for (int i = 1; i < pieces; i++)
                {
                    string filepath = string.Format("{0}/Part{1}{2}", destinationPath, i, fielInfo.Extension);
                    using (var destionation = new FileStream(filepath, FileMode.Create))
                    {
                        byte[] buffer = new byte[1024];
                        while (currentByte <= parthLengt * i)
                        {
                            int readBytesCount = source.Read(buffer, 0, buffer.Length);
                            if (readBytesCount == 0)
                            {
                                break;
                            }
                            destionation.Write(buffer, 0, readBytesCount);
                            currentByte += readBytesCount;
                        }

                    }

                    Console.WriteLine("Slicing completed");
                }

            }
        }
    }
}