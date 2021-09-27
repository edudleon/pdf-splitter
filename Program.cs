using System;

namespace PdfSplitter
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFilepath = @"C:\Users\Eduardo\source\repos\PdfSplitter\test.pdf";
            var outputFilepath = @"C:\Users\Eduardo\source\repos\PdfSplitter";
            var outputNamesFilepath = @"C:\Users\Eduardo\source\repos\PdfSplitter\test.csv";
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            PdfSplitter.PfSplitter.Split(inputFilepath, outputFilepath, outputNamesFilepath);
            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }
    }
}
