using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    interface Chatter
    {
        //méthode recevoir un message
        void ReceiveAMessage(string msg,Chatter c);

        //méthode pour obtenir le nom d'utilisateur du Chatter
        string GetAlias();
    }
}
