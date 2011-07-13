using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FastFood.Core.Services;
using FastFood.Core.Models;

namespace FastFood.Core.Security
{
    public class ClientSecurity : ISecurity
    {
        #region Constructor / Services
        private IClientServices _clientServices;

        public ClientSecurity() : this(new ClientServices())
        {
        }

        public ClientSecurity(IClientServices clientServices)
        {
            _clientServices = clientServices;
        }
        #endregion

        public bool ValidateUser(string user, string pass)
        {            
            ClientModel client = _clientServices.GetSingle(d => d.UserName == user);

            if (client == null)
                return false;

            return client.Password == pass;
        }

        public bool ChangePassword(string oldpass, string newpass, string user)
        {
            ClientModel client = _clientServices.GetSingle(d => d.UserName == user);
            
            if(client == null && client.Password == oldpass)
            {
                client.Password = newpass;
                _clientServices.Update(client);
                return true;
            }

            return false;
        }
    }
}
