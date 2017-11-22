using Chatprojet.Chat;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Server
{
    class TCPTopicsManager : TextGestTopics
    {
        #region field region

        private static int nextPort = 16000;
        private Dictionary<String, ServerChatRoom> tcpChatrooms = new Dictionary<String, ServerChatRoom>();

        #endregion

        #region methods

        public new void CreateTopic(String topic)
        {
            base.CreateTopic(topic);
            Chatroom chatroom = base.JoinTopic(topic);
            ServerChatRoom serverChatRoom = new ServerChatRoom(chatroom);
            tcpChatrooms.Add(topic, serverChatRoom);
            bool started = true;
            //Console.WriteLine("before while");
            do
            {
                try
                {
                    serverChatRoom.StartServer(nextPort);
                    started = true;
                }
                catch (IOException e)
                {
                    started = false;
                    Console.WriteLine(e.ToString());
                }
                nextPort++;
                //Console.WriteLine("in while");
            } while (!started);
            //Console.WriteLine("off while");
        }

        public int getTopicPort(String topic)
        {
            return tcpChatrooms[topic].Port;
        }

        #endregion
    }
}
