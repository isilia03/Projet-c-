using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    interface TopicsManager
    {
        List<string> ListTopic();
        Chatroom JoinTopic(String topic);
        void CreateTopic(String topic);
    }
}
