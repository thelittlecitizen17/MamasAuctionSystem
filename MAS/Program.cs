using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MAS
{
    class Program
    {
        static void Main(string[] args)
        {
            IProduct product1 = new OfficeBulding(4, 15, true, false, "Feldman");
            IProduct product2 = new OfficeBulding(2, 7, true, true, "BigBox");
            IProduct product3 = new OfficeBulding(40, 200, false, false, "Victory");
            IProduct product4 = new ResidentialBulding(5, 15, true, true, "Nisan 30 apr");
            IProduct product5 = new ResidentialBulding(1, 12, true, true, "Nisan 24 apr");
            IProduct product6 = new ResidentialBulding(3, 15, true, true, "Bialik 19 apr");

            IAgent agent1 = new Agent("Tomer" , 114000);
            IAgent agent2 = new Agent("Yasha", 209000);
            IAgent agent3 = new Agent("Alon", 110000);
            IAgent agent4 = new Agent("Ofir", 115000);
            IAgent agent5 = new Agent("Itay", 1000);

            List<IProduct> products = new List<IProduct>() {product1,product2};
            List<IAgent> agents = new List<IAgent>() { agent1, agent2, agent3, agent4, agent5 };

            var startDate1 = new DateTime(2020, 08, 27, 21, 05, 0);
            var startDate2 = new DateTime(2020, 08, 28, 21, 05, 0);

            IAuction auction1 = new Auction(product1, 100, 100000,4, startDate1);
            IAuction auction2 = new Auction(product2, 40, 10000,4, startDate2);

            List<IAuction> auctions = new List<IAuction>() { auction1,auction2 };

            SystemManager systemManager = new SystemManager(auctions,agents);
            AuctionStarterAsync(systemManager);
            Console.ReadLine();
        }
        static async void AuctionStarterAsync(SystemManager systemManager)
        {
            await systemManager.StartManagementParllelAsync();
        }
    }
}
