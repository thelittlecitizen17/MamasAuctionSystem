using System;
using System.Collections.Generic;
using System.Text;

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


        //public DateTime StartTime { get; set; }

        public Auction(IProduct product ,  double minJumping, double startingPrice )
        {
            Product = product;
            MinJumping = minJumping;
            StartingPrice = startingPrice;
            BestPrice = startingPrice;
            AgentsName = new List<string>();
            AuctionParticipants = new List<IAgent>();
            
        }

        public Auction(IProduct product , double bestPrice , double minjumping, double startingPrice , DateTime startTime)
        {
            Product = product;
            BestPrice = bestPrice;
            MinJumping = minjumping;
            StartingPrice = startingPrice;
            //StartTime = startTime;
        }
        public void SetAgentsToList(List<IAgent> agents)
        {

            foreach(var agentName in AgentsName)
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
