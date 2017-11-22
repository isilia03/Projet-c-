using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Net
{
    interface MessageConnection
    {
        Message GetMessage();

        void SendMessage(Message m);
    }
}
