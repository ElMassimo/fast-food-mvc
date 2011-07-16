using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Core.Models
{
    public class RestaurantModel
    {
        [Required]
        [Display(Name = "Name")]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        public AddressModel Address { get; set; }

        public IList<DeliveryBoyModel> DeliveryBoys { get; set; }
    }
}
