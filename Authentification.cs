using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Authentification
{
    class Authentification : AuthentificationManager
    {
        List<User> users;//Liste d'utilisateurs

        public Authentification()
        {
            users = new List<User>();
        }

        //Ajouter un utilisateur
        public void AddUser(string login, string password)
        {
            users.Add(new User(login, password));
        }

        //Supprimer un utilisateur
        public void RemoveUser(string login)
        {
            users.Remove(new User(login, ""));
        }
        //Méthode d'authentification
        public void Authentify(string login, string password)
        {
            users.Contains(new User(login, password));
        }

        //Charger le fichier des users
        public AuthentificationManager Load(String path)
        {
            throw new NotImplementedException();
        }

        //Sauvegarde les fichiers des users
        public void Save(String path)
        {
            throw new NotImplementedException();
        }
    }
}
