using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FastFood.Core.Models
{
    public class ClientModel
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

        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^[0-9]{8,9}$", ErrorMessage = "Not a valid phone number.")]
        [Display(Name = "Phone number")]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*\\.([a-z]{2,4})$",
        ErrorMessage = "Not a valid email adress.")]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }

        public AddressModel Address { get; set; }

        public OrderModel Orders { get; set; }
    }
}
