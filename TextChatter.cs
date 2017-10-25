using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
     class TextChatter : Chatter
    {
        string Alias;//le nom d'utilisateur du Chatter

        //Constructeur
        public TextChatter(string alias)
        {
            Alias = alias;
        }

        //méthode pour obtenir le nom d'utilisateur du Chatter
        public string GetAlias()
        {
            return Alias;
        }

        //méthode recevoir un message
        public void ReceiveAMessage(string msg, Chatter c)
        {
            
        }
    }
}
