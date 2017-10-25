using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Chatprojet.Chat
{
    interface TopicsManager
    {
        List<string> ListTopics();
        Chatroom JoinTopic(String topic);
        void CreateTopic(String topic);
    }
}
