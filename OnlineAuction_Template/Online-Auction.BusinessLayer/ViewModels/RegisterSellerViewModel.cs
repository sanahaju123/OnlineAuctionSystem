using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Auction.BusinessLayer.ViewModels
{
    public class RegisterSellerViewModel
    {
        [Key]
        public long SellerId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Maximum 100 characters")]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Maximum 100 characters")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "enter valid email address")]
        public string Email { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Maximum 10 characters")]
        public string Phone { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Maximum 100 characters")]
        public string Address { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
