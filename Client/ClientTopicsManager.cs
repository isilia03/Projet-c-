using Chat.Net;
using Chatprojet.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Client
{
    class ClientTopicsManager : TCPClient, TopicsManager
    {
        #region field region

        public enum Header { DEBUG, LIST_TOPIC, CREATE_TOPIC, JOIN_TOPIC, JOIN, POST, QUIT, GET, JOINED, LEFT }

        #endregion
        #region TopicsManager methods

        public List<string> ListTopics()
        {
            Message message = new Message((Message.Header)Header.LIST_TOPIC);
            List<String> topics = null;
            try
            {
                //Console.WriteLine("nous envoyons un message");
                SendMessage(message);
                //Console.WriteLine("message envoyé, nous attendons une réponse");
                Message answer = GetMessage();
                topics = answer.data;
                Console.WriteLine("liste des topic" + topics);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return topics;
        }

        public Chatroom JoinTopic(string topic)
        {
            Message message = new Message((Message.Header)Header.JOIN_TOPIC, topic);
            try
            {
                SendMessage(message);
                Message answer = GetMessage();

                int port;
                Int32.TryParse(answer.data[0],out port);

                ClientChatRoom chatroom = new ClientChatRoom();
                chatroom.SetServer(Adr, port);
                chatroom.Connect();
                Thread thread = new Thread(chatroom.Run);
                thread.Start();
                return chatroom;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public void CreateTopic(string topic)
        {
            Message message = new Message((Message.Header)Header.CREATE_TOPIC, topic);
            try
            {
                SendMessage(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        #endregion
    }
}
