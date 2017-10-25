using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    interface Chatroom
    {
        //Post un message
        void Post(string msg, Chatter c);

        //Quitter la chatroom
        void Quit(Chatter c);

        //Rejoindre la chatroom
        void Join(Chatter c);

        //Récuperer le Topic de la chatroom
        string getTopic();
    }
}
