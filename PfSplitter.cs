using Microsoft.VisualBasic.FileIO;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.IO;

namespace PdfSplitter
{
    class PfSplitter
    {
        static PfSplitter()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        public static (int, string) Split(string inputFilePath, string outputFilePath, string outputNamesFilepath)
        {
            PdfDocument inputDocument = PdfReader.Open(inputFilePath, PdfDocumentOpenMode.Import);
            string[] outputFileNames = splitNames(outputNamesFilepath);
            string name = Path.GetFileNameWithoutExtension(inputFilePath);
            for (int i = 0; i < inputDocument.PageCount; i++)
            {
                PdfDocument outputDocument = new PdfDocument();
                outputDocument.Info.Title = outputFileNames[i];
                outputDocument.AddPage(inputDocument.Pages[i]);
                string output = Path.Combine(outputFilePath, outputFileNames[i] + ".pdf");
                outputDocument.Save(output);
                outputDocument.Close();
            }
            inputDocument.Close();
            return (inputDocument.PageCount, outputFilePath);
        }
        private static string[] splitNames(string outputNamesFilepath)
        {
            TextFieldParser parser = new TextFieldParser(outputNamesFilepath);

            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            string[] names = null;
            while (!parser.EndOfData)
            {
                names = parser.ReadFields();
                  
            }
            return names;
        }

    }
}
