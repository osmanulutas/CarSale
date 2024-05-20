using AuctionService.Data;
using Contracts;
using MassTransit;

namespace AuctionService.Consumers
{
    public class BidPlacedConsumer(AuctionDbContext context) : IConsumer<BidPlaced>
    {
        public AuctionDbContext _context = context;
        public async Task Consume(ConsumeContext<BidPlaced> context)
        {

            Console.WriteLine("--> ${Consuming Bid Place}");
            var auction = await _context.Auctions.FindAsync(context.Message.AuctionId);

            if (auction.CurrentHighBid == null ||context.Message.BidStatus.Contains("Accepted") && context.Message.Amount > auction.CurrentHighBid)
            {
                auction.CurrentHighBid = context.Message.Amount;
                await _context.SaveChangesAsync();
            }
        }
    }
}
