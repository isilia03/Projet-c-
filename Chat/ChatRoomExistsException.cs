using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Chat
{
    class ChatRoomExistsException : Exception
    {
        public ChatRoomExistsException(string msg): base(msg)
        {

        }
    }
}
