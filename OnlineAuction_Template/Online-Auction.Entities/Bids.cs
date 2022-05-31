using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Auction.Entities
{
    public class Bids
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long BidId { get; set; }
        public long ProductId { get; set; }
        public long CustomerId { get; set; }
        public decimal BiddingAmount { get; set; }       
        public bool Status { get; set; }
    }
}
