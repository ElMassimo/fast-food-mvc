using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Core.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string DependentLocalityName { get; set; }

        [Required]
        [RegularExpression("^[0-9]{1,5}$", ErrorMessage = "Not a valid street number.")]
        [Display(Name = "Street number")]
        public int Number { get; set; }

        [Display(Name = "Apartment number")]
        public string ApartmentNumber { get; set; }

        [Required]
        [Display(Name = "Street")]
        [StringLength(30, MinimumLength = 3)]
        public string Street { get; set; }

        [Required]
        [Display(Name = "City")]
        [StringLength(30, MinimumLength = 3)]
        public string City { get; set; }

        [Display(Name = "State")]
        [StringLength(30, MinimumLength = 3)]
        public string State { get; set; }

        [Required]
        [Display(Name = "Country")]
        [StringLength(30, MinimumLength = 3)]
        public string Country { get; set; }

        [Display(Name = "Postal code")]
        public int? PostalCode { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(50);
            sb.AppendFormat("{0} {1}", Street, Number);
            if(!String.IsNullOrWhiteSpace(ApartmentNumber))
                sb.AppendFormat(" apt. {0}", ApartmentNumber);
            sb.AppendFormat(", {0}", City);
            if(!String.IsNullOrWhiteSpace(State) && !State.Equals(City))
                sb.AppendFormat(", {0}", State);
            sb.AppendFormat(", {0}", Country);
            return sb.ToString();
        }
    }
}
