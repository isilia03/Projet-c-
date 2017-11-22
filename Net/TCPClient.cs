using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Net
{
    class TCPClient : MessageConnection
    {
        #region field region

        private TcpClient comm;
        string adr;
        int port;

        #endregion

        #region Property

        public string Adr
        {
            get
            {
                return adr;
            }
        }

        #endregion

        #region methods

        public void SetServer(string adr, int port)//IPAdress c'est InetAdress en java
        {
            this.adr = adr;
            this.port = port;
        }

        public void Connect()
        {
            try
            {
                comm = new TcpClient(adr, port);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Disconnect()
        {
            try
            {
                comm.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        #endregion

        #region MessageConnection methods

        public Message GetMessage()
        {
            try
            {
                Stream input = comm.GetStream();

                BinaryFormatter bf = new BinaryFormatter();
                return (Message)bf.Deserialize(input);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
            }
            return null;
        }

        public void SendMessage(Message m)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(comm.GetStream(), m);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        #endregion
    }
}
