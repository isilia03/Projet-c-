using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    class AuthentificationException : Exception
    {
        public string Login { get; set; }

        /*public AuthentificationException() : base("Message random");
        {
            
        }*/
    }
}
