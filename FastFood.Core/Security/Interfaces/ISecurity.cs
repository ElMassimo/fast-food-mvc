using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastFood.Core.Security
{
    public interface ISecurity
    {
        /// <summary>
        /// Checks that the user password is correct
        /// </summary>
        bool ValidateUser(string user, string pass);

        /// <summary>
        /// Attempts to change the user password
        /// </summary>
        bool ChangePassword(string oldpass, string newpass, string user);

        /// <summary>
        /// Checks if the user exists
        /// </summary>
        bool IsUser(string user);
    }
}
