using System;
using System.Collections.Generic;
using System.Text;

namespace MAS
{
    class OfficeBulding : IBulding
    {
        public int NumberOfAirConditioners { get; set; }
        public double ProtectedSpaceSize { get; set; }
        public bool AccessToMainRoad { get; set; }
        public bool AccessForDisabled { get; set; }
        public string Name {get; set;}
        public string GuidNumber {get; set;}

        public OfficeBulding(int numberOfAirConditioners, double protectedSpaceSize, bool accessToMainRoad, bool accessForDisabled, string name)
        {
            NumberOfAirConditioners = numberOfAirConditioners;
            ProtectedSpaceSize = protectedSpaceSize;
            AccessForDisabled = accessForDisabled;
            AccessToMainRoad = accessToMainRoad;
            Name = name;
            GuidNumber = Guid.NewGuid().ToString();
        }
    }
}
