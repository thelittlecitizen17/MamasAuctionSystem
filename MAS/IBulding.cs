using System;
using System.Collections.Generic;
using System.Text;

namespace MAS
{
    interface IBulding:IProduct
    {
        int NumberOfAirConditioners { get; set; }
        double ProtectedSpaceSize { get; set; }
        bool AccessToMainRoad { get; set; }
        bool AccessForDisabled { get; set; }


        
    }
}
