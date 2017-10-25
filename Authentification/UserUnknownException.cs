using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Authentification
{
    class UserUnknownException : AuthentificationException
    {
        public UserUnknownException(string msg):base(msg)
        {
        }
    }
}
