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
        [Required(ErrorMessage = "First name required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The minimum length is 3 and the maximum length is 20")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last name required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The minimum length is 3 and the maximum length is 20")]        
        public string LastName { get; set; }

        [DisplayName("User Name")]
        [Required(ErrorMessage = "User name required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The minimum length is 3 and the maximum length is 20")]        
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The minimum length is 6 and the maximum length is 20")]   
        public string Password { get; set; }

        public int SuccesfulDeliveries { get; set; }

        public RestaurantModel Restaurant { get; set; }
        public IList<OrderModel> Orders { get; set; }
    }
}
