using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Authentification
{
    class UserExistsException : AuthentificationException
    {
        public UserExistsException(string msg):base(msg)
        {

        }
    }
}
