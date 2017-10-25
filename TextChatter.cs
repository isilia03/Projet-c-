using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    class TextChatter : Chatter
    {
        string Alias;

        public TextChatter(string alias)
        {
            Alias = alias;
        }

        public string GetAlias()
        {
            return Alias;
        }

        public void ReceiveAMessage(string msg, Chatter c)
        {
            throw new NotImplementedException();
        }
    }
}
