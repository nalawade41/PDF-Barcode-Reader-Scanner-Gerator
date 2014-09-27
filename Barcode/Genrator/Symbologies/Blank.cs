using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Base.Library.Barcode.GenratorPackage.Symbologies
{
    /// <summary>
    ///  Blank encoding template
    ///  Written by: Brad Barnhill
    /// </summary>
    class Blank : GenratorCommon, IBarcodeConstants
    {
        #region IBarcode Members

        public string Encoded_Value
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
