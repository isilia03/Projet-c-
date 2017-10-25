using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
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
            cr.Post("Toi aussi tu chat sur les forums de jeux pendant les TP,Bob ? ",joe);

            Console.ReadLine();
        }
    }
}
