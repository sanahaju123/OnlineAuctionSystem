using Microsoft.EntityFrameworkCore;
using Online_Auction.Entities;
using System;

namespace Online_Auction.DataLayer
{
    public class OnlineAuctionDbContext: DbContext
    {
        public OnlineAuctionDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Bids> Bids { get; set; }


    }
}

