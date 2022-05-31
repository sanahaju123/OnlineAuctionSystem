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
        [Key]
        public long ProductId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Maximum 100 characters")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Maximum 100 characters")]
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal StartBiddingAmount { get; set; }
        public decimal Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BiddingLastDate { get; set; }

        [Required]
        public long CategoryId { get; set; }
        [Required]
        public long SellerId { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
