using System.Drawing;

namespace Common.Base.Library.Barcode
{
    #region Enums

    public enum TYPE : int { UNSPECIFIED, UPCA, UPCE, UPC_SUPPLEMENTAL_2DIGIT, UPC_SUPPLEMENTAL_5DIGIT, EAN13, EAN8, Interleaved2of5, Standard2of5, Industrial2of5, CODE39, CODE39Extended, Codabar, PostNet, BOOKLAND, ISBN, JAN13, MSI_Mod10, MSI_2Mod10, MSI_Mod11, MSI_Mod11_Mod10, Modified_Plessey, CODE11, USD8, UCC12, UCC13, LOGMARS, CODE128, CODE128A, CODE128B, CODE128C, ITF14, CODE93, TELEPEN, FIM };
    public enum SaveTypes : int { JPG, BMP, PNG, GIF, TIFF, UNSPECIFIED };
    public enum AlignmentPositions : int { CENTER, LEFT, RIGHT };
    public enum LabelPositions : int { TOPLEFT, TOPCENTER, TOPRIGHT, BOTTOMLEFT, BOTTOMCENTER, BOTTOMRIGHT };

    #endregion

    public interface IBarcodeGenrator
    {
        Image Encode(TYPE iType, string StringToEncode, int Width, int Height);

        Image Encode(TYPE iType, string StringToEncode, Color ForeColor, Color BackColor, int Width, int Height);

        Image Encode(TYPE iType, string StringToEncode, Color ForeColor, Color BackColor);

        Image Encode(TYPE iType, string StringToEncode);

    }
}
