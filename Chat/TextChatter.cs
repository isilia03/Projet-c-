using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatprojet.Chat
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
            Console.WriteLine("(At " + Alias + ") : " + c.GetAlias() + " $> " + msg);
        }

        public void JoinNotification(Chatter c)
        {
            Console.WriteLine(c.GetAlias() + " join");
        }

        public void QuitNotification(Chatter c)
        {
            Console.WriteLine(c.GetAlias() + " quit");
        }
    }
}
