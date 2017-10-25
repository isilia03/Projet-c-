using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    class TextChatRoom : Chatroom
    {
        string Topic;//string contenant le topic de la chatroom
        List<Chatter> Chatters;//List contenant les chatters de la chatroom

        //Constructeur
        public TextChatRoom()
        {
            Chatters = new List<Chatter>();
        }

        //Récuperer le Topic de la chatroom
        public string getTopic()
        {
            return Topic;
        }

        //Rejoindre la chatroom
        public void Join(Chatter c)
        {
            Chatters.Add(c);
            Console.WriteLine("(Message from Chatroom : "+Topic+")"+ c.GetAlias() + "has join the room.");
        }

        //Post un message
        public void Post(string msg, Chatter c)
        {
            Console.WriteLine("(At "+c.GetAlias()+") : "+c.GetAlias()+" $> " +msg);
        }

        //Quitter la chatroom
        public void Quit(Chatter c)
        {
            Chatters.Remove(c);
            Console.WriteLine("(Message from Chatroom : " + Topic + ")" + c.GetAlias() + "has left the room.");
        }
    }
}
