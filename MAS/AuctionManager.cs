using System;
using System.Collections.Generic;
using System.Text;

namespace MAS
{
    class AuctionManager
    {
        public delegate void ActionProcessEventHandler(object obj, AuctionEventArg eventArgs);
        public event ActionProcessEventHandler ActionProcess;

        private IAuction _auction;


        public AuctionManager(IAuction auction)
        {
            _auction = auction;
        }
        public void Manage()
        {
            SubscribeAllAgents();
            while (!_checkIfAgentsIsDone())
            {
                onAuction();  
            }

            Console.WriteLine($"\nThe Auction is about to end... {_auction.BestOffersName} offered {_auction.BestPrice}");
            Console.WriteLine($"Does anyone want to make a new offer?");
            Console.WriteLine($"Going once.... Going twice...");
            if (!_checkIfAgentsIsDone())
            {
                Console.WriteLine("We are going again!!!");
                Manage();
            }
            else
            {
                Console.WriteLine($"\nThe Winner is ... {_auction.BestOffersName} !!! Congratulations !!!");

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
                ActionProcess(this, new AuctionEventArg() { Auction = _auction });

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
