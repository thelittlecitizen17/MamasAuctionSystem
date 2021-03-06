﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MAS
{
    class AuctionStarter
    {
        public delegate void AuctionStartedEventHandler(object obj, AuctionEventArg eventArgs);
        public event AuctionStartedEventHandler AuctionStarted;

        private IAuction _auction;
        private List<IAgent> _agents;
        public AuctionStarter(IAuction auction, List<IAgent> agents )
        {
            _auction = auction;
            _agents = agents;
        }
        public void startAuction()
        {
            
            Console.WriteLine($"\nThe {_auction.Product.Name} is offered for sale at a starting price of {_auction.StartingPrice} NIS. " +
                $" Minimum jump differences between bids and bids is {_auction.MinJumping} NIS");
            SubscribeAllAgents();
            onAuctionStarted();
            _auction.SetAgentsToList(_agents);
        }
        public void SubscribeAllAgents()
        {
            foreach(var agent in _agents)
            {
                AuctionStarted += agent.OnAuctionStarted;
            }
        }
        protected virtual void onAuctionStarted()
        {
            if (AuctionStarted != null)
            {
                var delegates = AuctionStarted.GetInvocationList();
                Parallel.ForEach(delegates, d => d.DynamicInvoke(this, new AuctionEventArg() { Auction = _auction }));
                //AuctionStarted(this, new AuctionEventArg() { Auction = _auction });

            }
        }


    }
}
