
using AppAuction.API.Entities;
using AppAuction.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AppAuction.API.UseCases.Auctions.GetCurrent;


public class GetCurrentAuctionUseCase
{
    public Auction? Execute()
    {
        var repository = new AppAuctionDbContext();

        var today = new DateTime(2024, 01, 21);
        var auction = repository.Auctions.Include(auction => auction.Items).FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
        return auction;
    }
}
