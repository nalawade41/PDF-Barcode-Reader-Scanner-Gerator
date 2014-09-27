using System.Collections;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Common.Base.Library.Barcode.ReaderPackage
{
    class Scanner : ScannerBusiness
    {
        public static ArrayList FullScanPage(Bitmap bmp, int numScans, ScanDirection direaction = ScanDirection.Both, BarcodeType barcodeType = BarcodeType.All)
        {
            ArrayList barcodeList = new ArrayList();
            if (direaction == ScanDirection.Both)
            {
                barcodeList.Add(ScanPage(bmp, numScans, ScanDirection.Vertical, barcodeType));
                barcodeList.Add(ScanPage(bmp, numScans, ScanDirection.Horizontal, barcodeType));
            }
            else
                barcodeList.Add(ScanPage(bmp, numScans, direaction, barcodeType));

            return barcodeList;
        }

        private static ArrayList ScanPage(Bitmap bmp, int numScans, ScanDirection direction, BarcodeType barcodeType)
        {
            int iHeight, iWidth;
            if (direction == ScanDirection.Horizontal)
            {
                iHeight = bmp.Width;
                iWidth = bmp.Height;
            }
            else
            {
                iHeight = bmp.Height;
                iWidth = bmp.Width;
            }

            if (numScans > iHeight)
                numScans = iHeight; // fix for doing full scan on small images

            ArrayList newList = new ArrayList();

            for (int i = 0; i < numScans; i++)
            {
                int y1 = (i * iHeight) / numScans;
                int y2 = ((i + 1) * iHeight) / numScans;
                string sCodesRead = ScanBarcodes(bmp, y1, y2, direction, barcodeType);

                if ((sCodesRead != null) && (sCodesRead.Length > 0))
                {
                    string[] asCodes = sCodesRead.Split('|');
                    foreach (string sCode in asCodes.ToList())
                        newList.Add(sCode);
                }
            }

            return newList;
        }

        private static string ScanBarcodes(Bitmap bmp, int start, int end, ScanDirection direction, BarcodeType types)
        {
            string sBarCodes = "|";

            //To find a horizontal barcode, find the vertical histogram to find individual barcodes, 
            //Then get the vertical histogram to decode each
            HistogramResult vertHist = VerticalHistogram(bmp, start, end, direction);

            //Get the light/dark bar patterns.
            //GetBarPatterns returns the bar pattern in 2 formats: 
            //sbCode39Pattern: for Code39 (only distinguishes narrow bars "n" and wide bars "w")
            //sbEANPattern: for EAN (distinguishes bar widths 1, 2, 3, 4 and L/G-code)

            StringBuilder sbCode39Pattern;
            StringBuilder sbEANPattern;

            GetBarPatterns(ref vertHist, out sbCode39Pattern, out sbEANPattern);

            // We now have a barcode in terms of narrow & wide bars... Parse it!
            if ((sbCode39Pattern.Length > 0) || (sbEANPattern.Length > 0))
            {
                for (int iPass = 0; iPass < 2; iPass++)
                {
                    if ((types & BarcodeType.Code39) != BarcodeType.None) // if caller wanted Code39
                    {
                        string sCode39 = ParseCode39(sbCode39Pattern);
                        if (sCode39.Length > 0)
                            sBarCodes += sCode39 + "|";
                    }
                    if ((types & BarcodeType.EAN) != BarcodeType.None) // if caller wanted EAN
                    {
                        string sEAN = ParseEAN(sbEANPattern);
                        if (sEAN.Length > 0)
                            sBarCodes += sEAN + "|";
                    }
                    if ((types & BarcodeType.Code128) != BarcodeType.None) // if caller wanted Code128
                    {
                        string sCode128 = ParseCode128(sbEANPattern);
                        if (sCode128.Length > 0)
                            sBarCodes += sCode128 + "|";
                    }

                    // Reverse the bar pattern arrays to read again in the mirror direction
                    if (iPass == 0)
                    {
                        sbCode39Pattern = ReversePattern(sbCode39Pattern);
                        sbEANPattern = ReversePattern(sbEANPattern);
                    }
                }
            }

            // Return pipe-separated list of found barcodes, if any
            if (sBarCodes.Length > 2)
                return sBarCodes.Substring(1, sBarCodes.Length - 2);
            return string.Empty;
        }
    }
}
