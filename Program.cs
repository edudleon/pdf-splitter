using System;

namespace PdfSplitter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escribe el directorio del archivo PDF a separar: ");
            var inputFilepath = Console.ReadLine();
            Console.WriteLine("Escribe el directorio destino de los archivos resultantes: ");
            var outputFilepath = Console.ReadLine();
            Console.WriteLine("Escribe el directorio del archivo csv con los nombres custom (si no está presente se darán nombres default):");
            var outputNamesFilepath = Console.ReadLine();
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            var outputs = PdfSplitter.PfSplitter.Split(inputFilepath, outputFilepath, outputNamesFilepath);
            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            Console.WriteLine($"Se separaron correctamente {outputs.Item1} archivos, en el directorio {outputs.Item2}");
        }
    }
}
