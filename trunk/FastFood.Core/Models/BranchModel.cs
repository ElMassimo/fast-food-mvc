using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastFood.Core.Models
{
    public class BranchModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AddressModel Address { get; set; }

        public IList<DeliveryBoyModel> DeliveryBoys { get; set; }
    }
}
