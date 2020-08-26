using System;
using System.Collections.Generic;
using System.Text;

namespace MAS
{
    interface IAgent
    {
        //List<IAuction> MyAuctions { get; set; }
        string Name { get; set; }
        double AccountBalance { get; set; }

        bool IsDone { get; set; }

        void OnMakeNewOffer(object obj, AuctionEventArg eventArgs);
        void MakeOfferWhenClosed();
        void OnAuctionStarted(object obj, AuctionEventArg eventArgs);
    }
}
