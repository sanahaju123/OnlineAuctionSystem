using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Auction.Entities
{
    public class Product
    {
        
        public enum Category
        {
            Mobiles=1,
            Electronics=2,
            Home=3,
            Clothing=5,
        }

        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal StartBiddingAmount { get; set; }
        public decimal Price { get; set; }
        public DateTime BiddingLastDate { get; set; }
        public Category CategoryId { get; set; }
        public long SellerId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
