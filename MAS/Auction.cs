using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;


namespace MAS
{
    class Auction : IAuction
    {
        public IProduct Product { get; set; }
        public List<string> AgentsName { get; set; }
        public List<IAgent> AuctionParticipants { get; set; }
        public double BestPrice { get; set; }
        public double MinJumping { get; set; }
        public double StartingPrice { get; set; }
        public string BestOffersName { get; set; }
        public Stopwatch AuctionTimer { get; set; }
        public double TimeToWait { get; set; }
        public DateTime StartTime { get; set; }

        public Auction(IProduct product ,  double minJumping, double startingPrice, int timeToWait , DateTime startTime)
        {
            Product = product;
            MinJumping = minJumping;
            StartingPrice = startingPrice;
            BestPrice = startingPrice;
            AgentsName = new List<string>();
            TimeToWait = new TimeSpan(0, 0, timeToWait).TotalSeconds;
            AuctionParticipants = new List<IAgent>();
            AuctionTimer = new Stopwatch();
            StartTime = startTime;
        }

        public void SetAgentsToList(List<IAgent> agents)
        {

            foreach (var agentName in AgentsName)
            {
                foreach(var agent in agents )
                {
                    if(agentName==agent.Name)
                    {
                        AuctionParticipants.Add(agent);
                    }
                }
            }
        }
    }
}
