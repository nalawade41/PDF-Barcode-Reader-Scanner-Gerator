using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Base.Library.Barcode.PDFConvert
{
    class PDFConverter
    {
        public static string ConvertPDFToImage(string fileName, string DLLPath)
        {
            string genratedImagePath;
            GhostScriptWrapper converter = new GhostScriptWrapper(DLLPath);
            converter.RenderingThreads = -1;
            converter.TextAlphaBit = -1;
            converter.TextAlphaBit = -1;
            converter.OutputToMultipleFile = true;
            converter.FirstPageToConvert = -1;
            converter.LastPageToConvert = -1;
            converter.FitPage = false;
            converter.JPEGQuality = 10;
            converter.OutputFormat = "png256";
            converter.ResolutionX = 500;
            converter.ResolutionY = 500;

            // Set the temprory drive to save genrated images 
            FileInfo input = new FileInfo(fileName);
            string directoryPath = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(input.Name));

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            genratedImagePath = directoryPath;
            string output = string.Format("{0}\\{1}{2}", directoryPath, input.Name, ".png");

            Console.WriteLine("File Processing Is " + fileName);

            //Call to ghostscript to convert the PDf to series of images
            converter.Convert(input.FullName, output);

            return genratedImagePath;
        }
    }
}
