using System;
using System.Collections.Generic;
using System.Text;

namespace MAS
{
    class SystemManager
    {
        public List<IAuction> Auctions { get; set; }
        public List<IAgent> Agents { get; set; }
        public SystemManager(List<IAuction> auctions , List<IAgent> agents)
        {
            Auctions = auctions;
            Agents = agents;
        }
        public void StartManagement()
        {
            while(Auctions.Count!=0)
            {
                for(int i=0; i<Auctions.Count; i++)
                {
                    if(true)
                    {
                        AuctionStarter auctionStarter = new AuctionStarter(Auctions[i],Agents);
                        auctionStarter.startAuction();
                        if (Auctions[i].AgentsName.Count != 0)
                        {
                            AuctionManager auctionManager = new AuctionManager(Auctions[i]);
                            Console.WriteLine($"\nThe auction starts now!!! The min price is : {Auctions[i].BestPrice}");
                            auctionManager.Manage();
                            _restAgentsFlag();
                            Auctions.RemoveAt(Auctions.IndexOf(Auctions[i]));
                            i--;

                        }
                        else
                        {
                           Auctions.RemoveAt(Auctions.IndexOf(Auctions[i]));
                            i--;
                        }

                    }
                }

            }
        }
        private void _restAgentsFlag()
        {
            foreach(var agent in Agents)
            {
                agent.IsDone = false;
            }
        }


    }
}
