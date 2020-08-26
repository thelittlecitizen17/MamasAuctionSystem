using System;
using System.Collections.Generic;
using System.Text;

namespace MAS
{
    class Agent : IAgent
    {
        public List<IAuction> MyAuctions = new List<IAuction>();
        public string Name { get; set; }
        public double AccountBalance { get; set; }
        public bool IsDone { get; set ; }

        public Agent(string name , double accountBalance)
        {
            Name = name;
            AccountBalance = accountBalance;
            IsDone = false;
        }


        public void OnMakeNewOffer(object obj, AuctionEventArg eventArgs)
        {
            if (AccountBalance >= eventArgs.Auction.BestPrice)
            {
                double offer = _offer(eventArgs);
                Console.WriteLine($"{Name} is offering {offer} for {eventArgs.Auction.Product.Name}");
                if (offer > eventArgs.Auction.BestPrice)
                {
                    eventArgs.Auction.BestPrice = offer;
                    eventArgs.Auction.BestOffersName = Name;
                    AccountBalance = AccountBalance - (offer-eventArgs.Auction.StartingPrice);
                    //timer inside auction = 00:00:00

                }
                else
                {
                    
                }

            }
            else
            {
                IsDone = true;
            }
           

        }

        public void MakeOfferWhenClosed()
        {
            throw new NotImplementedException();
        }
        public void OnAuctionStarted(object source, AuctionEventArg eventArgs)
        {
            if (AccountBalance >= eventArgs.Auction.StartingPrice)
            {


                Console.WriteLine($"\n{Name} is Enterd to Auction!!! I Will buy{eventArgs.Auction.Product.Name}");
                if (!MyAuctions.Contains(eventArgs.Auction))
                {
                    
                    MyAuctions.Add(eventArgs.Auction);
                    eventArgs.Auction.AgentsName.Add(Name);
                    
                }
               
            }
            else
            {
                Console.WriteLine($"\n{Name} has NO MONEY!!!");
                
            }
        }
        private double _offer(AuctionEventArg eventArgs)
        {
            double offer = eventArgs.Auction.BestPrice + eventArgs.Auction.MinJumping;
            return offer;
        }
    }
}
