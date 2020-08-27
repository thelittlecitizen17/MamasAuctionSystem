using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        public async Task StartManagementParllelAsync()
        {
            List<Task> tasks = new List<Task>();
            while (Auctions.Count != 0)
            {
                foreach(var auction in Auctions)
                {
                    if (auction.StartTime.ToString("yyyyMMddhhmm") == DateTime.Now.ToString("yyyyMMddhhmm")) 
                    {
                        tasks.Add(Task.Run(() => _auctionCall(auction)));
                    }
                }

                Task.WaitAll(tasks.ToArray());

            }
            Console.WriteLine("\nWe are done! Thank you :)");

        }

        private void _auctionCall(IAuction auction)
        {
            AuctionStarter auctionStarter = new AuctionStarter(auction, Agents);
            auctionStarter.startAuction();
            if (auction.AgentsName.Count != 0)
            {
                AuctionManager auctionManager = new AuctionManager(auction);
                Console.WriteLine($"\nThe auction on {auction.Product.Name} starts now!!! The min price is : {auction.BestPrice}");
                auctionManager.Manage();
                _restAgentsFlag();
                Auctions.RemoveAt(Auctions.IndexOf(auction));
               

            }
            else
            {
                Auctions.RemoveAt(Auctions.IndexOf(auction));
               
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
