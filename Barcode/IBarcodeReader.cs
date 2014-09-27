using System.Collections;
using System.Drawing;

namespace Common.Base.Library.Barcode
{
    #region Public Variables

    /// <summary>
    /// Type of barcode to read
    /// </summary>
    public enum BarcodeType
    {
        /// <summary>Not specified</summary>
        None = 0,
        /// <summary>Code39</summary>
        Code39 = 1,
        /// <summary>EAN/UPC</summary>
        EAN = 2,
        /// <summary>Code128</summary>
        Code128 = 4,
        /// <summary>Use BarcodeType.All for all supported types</summary>
        All = Code39 | EAN | Code128
    }

    /// <summary>
    /// Used to specify whether to scan a page in vertical direction,
    /// horizontally, or both.
    /// </summary>
    public enum ScanDirection
    {
        /// <summary>Scan top-to-bottom</summary>
        Vertical = 1,
        /// <summary>Scan left-to-right</summary>
        Horizontal = 2,
        /// <summary>
        /// Scan fromm both direactions
        /// </summary>
        Both = 3
    }

    #endregion

    public interface IBarcodeReader
    {

        ArrayList ReadBarcode(string filePath, BarcodeType barcodeType, string ghostScriptDLLPath);

        ArrayList ReadBarcode(Bitmap image, BarcodeType barcodeType);

        ArrayList ReadBarcode(string filePath, BarcodeType barcodeType, ScanDirection direcation, string ghostScriptDLLPath);

        ArrayList ReadBarcode(Bitmap image, BarcodeType barcodeType, ScanDirection direcation);

        ArrayList ReadBarcode(string filePath, BarcodeType barcodeType, int numberOfPasses, string ghostScriptDLLPath);

        ArrayList ReadBarcode(Bitmap image, BarcodeType barcodeType, int numberOfPasses);

        ArrayList ReadBarcode(string filePath, BarcodeType barcodeType, ScanDirection direcation, int numberOfPasses, string ghostScriptDLLPath);

        ArrayList ReadBarcode(Bitmap image, BarcodeType barcodeType, ScanDirection direcation, int numberOfPasses);

    }

}
