using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    interface AuthentificationManager
    {
        void AddUser(String login, String password);
        void removeUser(String login);
        void authentify(String login, String password);
        static AuthentificationManager load(String path);
        void save(String path);
    }
}
