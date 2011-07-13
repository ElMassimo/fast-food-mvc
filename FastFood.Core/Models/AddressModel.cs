using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastFood.Core.Models
{
    public class AddressModel
    {
        public int Id { get; set; }

        public int Number { get; set; }
        public int? ApartmentNumber { get; set; }
        public string Street { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int? PostalCode { get; set; }
    }
}
