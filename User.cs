using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Authentification
{
    class User : IComparable
    {
        string Login { get; }
        string _password;

        public User(string login,string password)
        {
            Login = login;
            _password = password;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            User otherUser = obj as User;
            if (otherUser != null)
            {
                if (otherUser._login == this._login)
                    return 0;
                else
                    return 1;
            }
            else
                throw new ArgumentException("Object is not a User");
        }
    }
}
