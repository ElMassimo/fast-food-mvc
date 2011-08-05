using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Core.Models
{
    public class DeliveryBoyModel
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required]
        [StringLength(20, MinimumLength = 3)]        
        public string LastName { get; set; }

        [DisplayName("User Name")]
        [Required]
        [StringLength(20, MinimumLength = 3)]        
        public string Nick { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
        
        public int SuccesfulDeliveries { get; set; }

        public RestaurantModel Restaurant { get; set; }
        public IEnumerable<OrderModel> Orders { get; set; }
    }
}
