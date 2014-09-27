using Common.Base.Library.Barcode.PDFConvert;
using Common.Base.Library.Barcode.ReaderPackage;
using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace Common.Base.Library.Barcode
{
    public class Reader : IBarcodeReader, IDisposable
    {
        public string GhostScriptDLLPath { get; set; }

        private string _ghostScriptDLLPath { get { return this.GhostScriptDLLPath; } }

        public ArrayList ReadBarcode(string filePath, BarcodeType barcodeType, string ghostScriptDLLPath)
        {
            ArrayList barcodeList = new ArrayList();
            int numberOfScan = 100;

            bool Win32 = Marshal.SizeOf(typeof(IntPtr)) == 4;

            try
            {
                string imagesPath = PDFConverter.ConvertPDFToImage(filePath, ghostScriptDLLPath);

                foreach (FileInfo image in (new DirectoryInfo(imagesPath)).GetFiles("*.png"))
                {
                    ArrayList temproryList = new ArrayList();
                    using (Bitmap bitmap = new Bitmap(image.FullName))
                    {
                        temproryList = Scanner.FullScanPage(bitmap, numberOfScan, ScanDirection.Both, barcodeType);
                    }
                    foreach (var element in temproryList)
                    {
                        if (element != null)
                            barcodeList.Add(element);
                    }
                }
                return barcodeList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public ArrayList ReadBarcode(Bitmap image, BarcodeType barcodeType)
        {
            ArrayList barcodeList = new ArrayList();
            int numberOfScan = 100;
            ArrayList temproryList = new ArrayList();
            temproryList = Scanner.FullScanPage(image, numberOfScan, ScanDirection.Both, barcodeType);
            foreach (var element in temproryList)
            {
                if (element != null)
                    barcodeList.Add(element);
            }
            return barcodeList;
        }

        public ArrayList ReadBarcode(string filePath, BarcodeType barcodeType, ScanDirection direcation, string ghostScriptDLLPath)
        {
            ArrayList barcodeList = new ArrayList();
            int numberOfScan = 100;

            bool Win32 = Marshal.SizeOf(typeof(IntPtr)) == 4;

            try
            {
                string imagesPath = PDFConverter.ConvertPDFToImage(filePath, ghostScriptDLLPath);

                foreach (FileInfo image in (new DirectoryInfo(imagesPath)).GetFiles("*.png"))
                {
                    ArrayList temproryList = new ArrayList();
                    using (Bitmap bitmap = new Bitmap(image.FullName))
                    {
                        temproryList = Scanner.FullScanPage(bitmap, numberOfScan, direcation, barcodeType);
                    }
                    foreach (var element in temproryList)
                    {
                        if (element != null)
                            barcodeList.Add(element);
                    }
                }
                return barcodeList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }


        }

        public ArrayList ReadBarcode(Bitmap image, BarcodeType barcodeType, ScanDirection direcation)
        {
            ArrayList barcodeList = new ArrayList();
            int numberOfScan = 100;
            ArrayList temproryList = new ArrayList();
            temproryList = Scanner.FullScanPage(image, numberOfScan, direcation, barcodeType);
            foreach (var element in temproryList)
            {
                if (element != null)
                    barcodeList.Add(element);
            }
            return barcodeList;
        }

        public ArrayList ReadBarcode(string filePath, BarcodeType barcodeType, int numberOfPasses, string ghostScriptDLLPath)
        {

            ArrayList barcodeList = new ArrayList();

            bool Win32 = Marshal.SizeOf(typeof(IntPtr)) == 4;
            try
            {
                string imagesPath = PDFConverter.ConvertPDFToImage(filePath, ghostScriptDLLPath);

                foreach (FileInfo image in (new DirectoryInfo(imagesPath)).GetFiles("*.png"))
                {
                    ArrayList temproryList = new ArrayList();
                    using (Bitmap bitmap = new Bitmap(image.FullName))
                    {
                        temproryList = Scanner.FullScanPage(bitmap, numberOfPasses, ScanDirection.Both, barcodeType);
                    }
                    foreach (var element in temproryList)
                    {
                        if (element != null)
                            barcodeList.Add(element);
                    }
                }
                return barcodeList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public ArrayList ReadBarcode(Bitmap image, BarcodeType barcodeType, int numberOfPasses)
        {
            ArrayList barcodeList = new ArrayList();
            ArrayList temproryList = new ArrayList();
            temproryList = Scanner.FullScanPage(image, numberOfPasses, ScanDirection.Both, barcodeType);
            foreach (var element in temproryList)
            {
                if (element != null)
                    barcodeList.Add(element);
            }
            return barcodeList;
        }

        public ArrayList ReadBarcode(string filePath, BarcodeType barcodeType, ScanDirection direcation, int numberOfPasses, string ghostScriptDLLPath)
        {

            ArrayList barcodeList = new ArrayList();

            bool Win32 = Marshal.SizeOf(typeof(IntPtr)) == 4;
            try
            {
                string imagesPath = PDFConverter.ConvertPDFToImage(filePath, ghostScriptDLLPath);

                foreach (FileInfo image in (new DirectoryInfo(imagesPath)).GetFiles("*.png"))
                {
                    ArrayList temproryList = new ArrayList();
                    using (Bitmap bitmap = new Bitmap(image.FullName))
                    {
                        temproryList = Scanner.FullScanPage(bitmap, numberOfPasses, direcation, barcodeType);
                    }
                    foreach (var element in temproryList)
                    {
                        if (element != null)
                            barcodeList.Add(element);
                    }
                }
                return barcodeList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public ArrayList ReadBarcode(Bitmap image, BarcodeType barcodeType, ScanDirection direcation, int numberOfPasses)
        {
            ArrayList barcodeList = new ArrayList();
            ArrayList temproryList = new ArrayList();
            temproryList = Scanner.FullScanPage(image, numberOfPasses, direcation, barcodeType);
            foreach (var element in temproryList)
            {
                if (element != null)
                    barcodeList.Add(element);
            }
            return barcodeList;
        }

        public void Dispose()
        {
            try
            {
            }//try
            catch (Exception ex)
            {
                throw new Exception("EDISPOSE-1: " + ex.Message);
            }//catch
        }
    }
}
