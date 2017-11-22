using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Net
{
    abstract class TCPServer: MessageConnection,ICloneable
    {
        #region Field region

        private enum Mode { treatClient,treatConnections}
        Mode mode = Mode.treatConnections;
        public TcpClient comm;
        TcpListener waitSock;//ServerSocket in java
        int port;

        #endregion

        #region Property

        public int Port
        {
            get
            {
                return port;
            }
        }

        #endregion

        #region methods

        public void StartServer(int port)
        {
            try
            {
                waitSock = new TcpListener(new IPAddress(new byte[] { 127, 0, 0, 1 }), port);
                waitSock.Start();
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }
        }

        public void StopServer()
        {
            try
            {
                waitSock.Stop();
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }
        }

        public void Run()
        {
            if(mode == Mode.treatConnections)
            {
                while(true)
                {
                    try
                    {
                        comm = waitSock.AcceptTcpClient();
                        TCPServer myClone = (TCPServer)this.Clone();
                        myClone.mode = Mode.treatClient;
                        new Thread(myClone.GereClient).Start();
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine(e);
                    }
                    catch (NotSupportedException e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
        }

        #endregion

        #region abstact methods

        abstract public void GereClient();

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
                Console.WriteLine(e);
            }
            return null;
        }

        public void SendMessage(Message m)
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(comm.GetStream(), m);
        }

        #endregion

        #region Cloneable methods

        public object Clone()
        {
            Object o = this.Clone();

            return o;
        }

        #endregion 
    }
}
