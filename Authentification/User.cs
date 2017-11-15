using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Authentification
{
    [Serializable]
    class User : IComparable
    {
        public string Login { get; }
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
                if (otherUser.Login == this.Login)
                    return 0;
                else
                    return 1;
            }
            else
                throw new ArgumentException("Object is not a User");
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // TODO: write your implementation of Equals() here
            User otherUser = obj as User;
            if (!this.Login.Equals(otherUser.Login))
                return false;
            if (!this._password.Equals(otherUser._password))
                return false;
            return true;
        }
    }
}
