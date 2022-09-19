using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Auction.BusinessLayer.ViewModels
{
    public class RegisterProductViewModel
    {
        public long ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public int Quantity { get; set; }
        
        public decimal StartBiddingAmount { get; set; }
        
        public decimal Price { get; set; }

        public DateTime BiddingLastDate { get; set; }

        public long CategoryId { get; set; }
      
        public long SellerId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
