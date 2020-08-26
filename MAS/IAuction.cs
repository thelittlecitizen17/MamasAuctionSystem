using System;
using System.Collections.Generic;
using System.Text;

namespace MAS
{
    interface IAuction
    {
        IProduct Product { get; set; }
        List<string> AgentsName { get; set; }
        double BestPrice { get; set; }
        double MinJumping { get; set; }

        //DateTime StartTime { get; set; }
        double StartingPrice { get; set; }
        void SetAgentsToList(List<IAgent> agents);

        List<IAgent> AuctionParticipants { get; set; }
        string BestOffersName { get; set; }
    }
}
