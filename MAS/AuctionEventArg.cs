using System;
using System.Collections.Generic;
using System.Text;

namespace MAS
{
    class AuctionEventArg:EventArgs
    {
        public IAuction Auction { get; set; }
    }
}
