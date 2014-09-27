using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Base.Library.Barcode.GenratorPackage
{
    interface IBarcodeConstants
    {
        string Encoded_Value
        {
            get;
        }//Encoded_Value

        string RawData
        {
            get;
        }//Raw_Data

        List<string> Errors
        {
            get;
        }//Errors
    }
}
