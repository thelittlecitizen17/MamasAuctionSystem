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
                for (int i = 0; i < Auctions.Count; i++)
                {
                    if (true)
                    {

                        tasks.Add(Task.Run(() => _auctionCall(ref i)));

                        //_auctionCall(ref i);
                    }
                }

                Task.WaitAll(tasks.ToArray());

            }
        }
        public async Task StartManagementSync()
        {
            while(Auctions.Count!=0)
            {
                for(int i=0; i<Auctions.Count; i++)
                {
                    if(true)
                    {
                        
                        await Task.Run(() => _auctionCall(ref i));
                        
                        //_auctionCall(ref i);
                    }
                }

            }
        }
        private void _auctionCall(ref int i)
        {
            AuctionStarter auctionStarter = new AuctionStarter(Auctions[i], Agents);
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
        private void _restAgentsFlag()
        {
            foreach(var agent in Agents)
            {
                agent.IsDone = false;
            }
        }


    }
}
