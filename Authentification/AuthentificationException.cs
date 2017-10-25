using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Authentification
{
    class AuthentificationException : Exception
    {
        public string Login { get; set; }

        public AuthentificationException(string msg): base(msg)
        {

        }
    }
}
