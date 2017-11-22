using Chat.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Chatprojet.Chat;

namespace Chat.Server
{
    class ServerTopicsManager : TCPServer
    {
        #region field region

        private TCPTopicsManager tcpTopicsManager = new TCPTopicsManager();
        public enum Header { DEBUG, LIST_TOPIC, CREATE_TOPIC, JOIN_TOPIC, JOIN, POST, QUIT, GET, JOINED, LEFT }

        #endregion

        #region TCPServer methods

        public override void GereClient()
        {
            try
            {
                Message inputMessage;
                while ((inputMessage = GetMessage()) != null)
                {
                    //System.out.println("Got Message2" + inputMessage.head);

                    switch (inputMessage.head)
                    {
                        case (Message.Header)Header.LIST_TOPIC:
                            //System.out.println("Got Message");
                            List<String> topics = tcpTopicsManager.ListTopics();
                            Message outputMessage1 = new Message((Message.Header)Header.LIST_TOPIC, topics);
                            SendMessage(outputMessage1);
                            break;
                        case (Message.Header)Header.CREATE_TOPIC:
                            //System.out.println("Got Message 3");
                            tcpTopicsManager.CreateTopic(inputMessage.data[0]);
                            break;
                        case (Message.Header)Header.JOIN_TOPIC:
                            String topicToJoin = inputMessage.data[0];
                            Message outputMessage3 = new Message((Message.Header)Header.JOIN_TOPIC,tcpTopicsManager.getTopicPort(topicToJoin).ToString());
                            SendMessage(outputMessage3);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        #endregion
    }
}
