using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FastFood.Dal.EntityModels;
using FastFood.Core.Models;
using FastFood.Dal.Repositories;

namespace FastFood.Core.Services
{
    public class AddressServices : BaseServices<Address, AddressModel>
    {
        public AddressServices()
            : base(new AddressRepository())
        {

        }
    }
}
