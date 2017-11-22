using Chat.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Chatprojet.Chat;
using System.IO;

namespace Chat.Server
{
    class ServerChatRoom : TCPServer, Chatter
    {
        #region field region

        private string pseudo;
        TextChatRoom concretCR;
        public enum Header { DEBUG, LIST_TOPIC, CREATE_TOPIC, JOIN_TOPIC, JOIN, POST, QUIT, GET, JOINED, LEFT }

        #endregion

        #region Constructor

        public ServerChatRoom(Chatroom chatroom)
        {
            concretCR = (TextChatRoom)chatroom;
        }

        #endregion
        #region TCPServer methods

        public override void GereClient()
        {
            try
            {
                Message inputMessage;

                while ((inputMessage = GetMessage()) != null)
                {
                    switch (inputMessage.head)
                    {
                        case (Message.Header)Header.JOIN:
                            Console.WriteLine("un message JOIN reu");
                            pseudo = inputMessage.data[0];
                            concretCR.Join(this);
                            break;
                        case (Message.Header)Header.POST:
                            Console.WriteLine("un message POST reu");
                            String message = inputMessage.data[1];
                            concretCR.Post(message, this);
                            break;
                        case (Message.Header)Header.QUIT:
                            Console.WriteLine("un message QUIT reu");
                            concretCR.Quit(this);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        #endregion

        #region Chatter methods

        public string GetAlias()
        {
            return pseudo;
        }

        public void ReceiveAMessage(string msg, Chatter c)
        {
            List<String> data = new List<String>(2);
            data.Add(c.GetAlias());
            data.Add(msg);
            try
            {
                SendMessage(new Message((Message.Header)Header.GET, data));
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }
        }

        public void JoinNotification(Chatter c)
        {
            Console.WriteLine(c.GetAlias() + " join");
        }

        public void QuitNotification(Chatter c)
        {
            Console.WriteLine(c.GetAlias() + " quit");
        }

        #endregion
    }
}
