using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    class TextGestTopics : TopicsManager
    {
        private List<string> _topic;

        TextGestTopics()
        {
            _topic = new List<string>();
        }

        public void createTopic(string topic)
        {
            _topic.Add(topic);
            Console.WriteLine("nouveau topic créé");
        }

        public Chatroom joinTopic(string topic)
        {
            throw new NotImplementedException();
        }

        public List<string> listTopic()
        {
            return _topic;
        }
    }
}