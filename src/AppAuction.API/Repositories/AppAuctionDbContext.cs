using AppAuction.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppAuction.API.Repositories;



public class AppAuctionDbContext: DbContext
{

    public DbSet<Auction> Auctions { get; set; }
    public DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=/Users/paulospiguel/devSpace/dotnet-learn/AppAuctionApi/database/leilaoDbNLW.db");
    }

}