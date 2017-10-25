using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    class TextGestTopics : TopicsManager
    {
        private List<string> _topics;

        public TextGestTopics()
        {
            _topics = new List<string>();
        }

        public void CreateTopic(string topic)
        {
            _topics.Add(topic);
            Console.WriteLine("nouveau topic créé");
        }

        public Chatroom JoinTopic(string topic)
        {
            TextChatRoom c = new TextChatRoom();
            c.Topic = topic;
            return c;
        }

        public List<string> ListTopic()
        {
            Console.WriteLine("The openned topics are: ");
            foreach (string topic in _topics)
            {
                Console.WriteLine(topic);
            }

            return _topics;
        }
    }
}
