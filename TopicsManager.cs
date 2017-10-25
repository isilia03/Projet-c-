using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    interface TopicsManager
    {
         listTopic();
        Chatroom joinTopic(String topic);
        void createTopic(String topic);
    }
}
