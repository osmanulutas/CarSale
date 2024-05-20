using AuctionService.Data;
using Contracts;
using MassTransit;

namespace AuctionService.Consumers
{
    public class AuctionFinishedConsumer(AuctionDbContext context) : IConsumer<AuctionFinished>
    {
        public AuctionDbContext _context = context;

        public async Task Consume(ConsumeContext<AuctionFinished> context)
        {
            Console.WriteLine("--> ${Consuming Auction Finished}");
            var auction = await _context.Auctions.FindAsync(context.Message.AuctionId);
            if (context.Message.ItemSold)
            {
                auction.Winner = context.Message.Winner;
                auction.SoldAmount = context.Message.Amount;
            }
            auction.Status = auction.SoldAmount > auction.ReservePrice ? Entities.Status.Finished : Entities.Status.ReserveNotMet;

            await _context.SaveChangesAsync();
        }
    }
}
