using Chat.Authentification;
using Chatprojet.Chat;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProjet
{
    class Program
    {
        static void Main(string[] args)
        {
            Chatter bob = new TextChatter("Bob");
            Chatter joe = new TextChatter("Joe");
            TopicsManager gt = new TextGestTopics();

            gt.CreateTopic("java");
            gt.CreateTopic("UML");
            gt.ListTopics();
            gt.CreateTopic("jeux");
            gt.ListTopics();
            Chatroom cr = gt.JoinTopic("jeux");
            cr.Join(bob);
            cr.Post("Je suis seul ou quoi ?", bob);
            cr.Join(joe);
            cr.Post("Tiens, salut Joe !", bob);
            cr.Post("Toi aussi tu chat sur les forums de jeux pendant les TP,Bob ? ", joe);

            AuthentificationManager am = new Authentification();

            // users management

            try
            {
                am.AddUser("bob", "123");
                Console.WriteLine("Bob has been added !");
                am.RemoveUser("bob");
                Console.WriteLine("Bob has been removed !");
                am.RemoveUser("bob");
                Console.WriteLine("Bob has been removes twice !");
            }
            catch (UserUnknownException e)
            {
                Console.WriteLine(e.Login + " : user unknown (enable to remove)!");
            }
            catch (UserExistsException e)
            {
                Console.WriteLine(e.Login + " has already been added !");
            }

            // authentification
            try
            {
                am.AddUser("bob", "123");
                Console.WriteLine("Bob has been added !");
                am.Authentify("bob", "123");
                Console.WriteLine("Authentification OK !");
                am.Authentify("bob", "456");
                Console.WriteLine("Invalid password !");
            }
            catch (WrongPasswordException e)
            {
                Console.WriteLine(e.Login + " has provided an invalid password !");
            }
            catch (UserExistsException e)
            {
                Console.WriteLine(e.Login + " has already been added !");

            }
            catch (UserUnknownException e)
            {
                Console.WriteLine(e.Login + " : user unknown (enable to remove)!");
            }

            // persistance
            try
            {
                am.Save("users.txt");
                AuthentificationManager am1 = new Authentification();
                am1.Load("users.txt");
                am1.Authentify("bob", "123");
                Console.WriteLine("Loading complete !");
            }
            catch (UserUnknownException e)
            {
                Console.WriteLine(e.Login + " is unknown ! error during the saving / loading.");
            }
            catch (WrongPasswordException e)
            {
                Console.WriteLine(e.Login + " has provided an invalid password!error during the saving / loading.");
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }


            Console.ReadLine();
        }
    }
}
