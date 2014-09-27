
namespace Common.Base.Library.Barcode.ReaderPackage
{
    struct BarcodeZone
    {
        public int Start;
        public int End;
    }

    class HistogramResult
    {
        /// <summary>Averaged image brightness values over one scanned band</summary>
        public byte[] histogram;
        /// <summary>Minimum brightness (darkest)</summary>
        public byte min; // 
        /// <summary>Maximum brightness (lightest)</summary>
        public byte max;

        public byte threshold;     // threshold brightness to detect change from "light" to "dark" color
        public float lightnarrowbarwidth; // narrow bar width for light bars
        public float darknarrowbarwidth;  // narrow bar width for dark bars
        public float lightwiderbarwidth;  // width of most common wider bar for light bars
        public float darkwiderbarwidth;   // width of most common wider bar for dark bars

        public BarcodeZone[] zones; // list of zones on the current band that might contain barcode data
    }
}
