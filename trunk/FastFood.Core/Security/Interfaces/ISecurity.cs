using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastFood.Core.Security
{
    public interface ISecurity
    {
        bool ValidateUser(string user, string pass);
        bool ChangePassword(string oldpass, string newpass, string user);
    }
}
