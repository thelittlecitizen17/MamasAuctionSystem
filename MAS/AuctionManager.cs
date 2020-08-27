using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MAS
{
    class AuctionManager
    {
        public delegate void ActionProcessEventHandler(object obj, AuctionEventArg eventArgs);
        public event ActionProcessEventHandler ActionProcess;
        private object _myLocker = new object();
        private IAuction _auction;

        public AuctionManager(IAuction auction)
        {
            _auction = auction;
        }
        public void Manage()
        {
            SubscribeAllAgents();
            while (!_checkIfAgentsIsDone() || _auction.TimeToWait<=_auction.AuctionTimer.Elapsed.Seconds)
            {
                lock (_myLocker)
                {
                    _auction.AuctionTimer.Reset();
                }
                onAuction();  
            }

            Console.WriteLine($"\nThe Auction is about to end... {_auction.BestOffersName} offered {_auction.BestPrice} for {_auction.Product.Name}\n" +
                $"Does anyone want to make a new offer?\n" +
                $"Going once.... Going twice...");

            if (!_checkIfAgentsIsDone())
            {
                Console.WriteLine("We are going again!!!");
                Manage();
            }
            else
            {
                Console.WriteLine($"\n{_auction.Product.Name} is sold! The Winner is ... {_auction.BestOffersName} !!! Congratulations !!!");

            }

  
        }
        public void SubscribeAllAgents()
        {
            foreach (var agent in _auction.AuctionParticipants)
            {
                ActionProcess += agent.OnMakeNewOffer;
            }
        }
        protected virtual void onAuction()
        {
            if (ActionProcess != null)
            {
                var delegates = ActionProcess.GetInvocationList();
                Parallel.ForEach(delegates, d => d.DynamicInvoke(this, new AuctionEventArg() { Auction = _auction }));
            }
        }

        private bool _checkIfAgentsIsDone()
        {
            int count= 0;
            foreach(var agent in _auction.AuctionParticipants)
            {
                if(agent.IsDone)
                {
                    count++;
                }
            }
            if(count+1 == _auction.AuctionParticipants.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
