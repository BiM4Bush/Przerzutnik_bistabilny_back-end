using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban
{
    class Program
    {
        static void Main(string[] args)
        {
            string appName = "Kanban table";
            int appVersion = 1;
            string [] authors = new string [6];
            authors[0] = "Sebastian Krzynówek";
            authors[1] = "Mateusz Kowalewski";
            authors[2] = "Paweł Kulesza";
            authors[3] = "Marcin Kozłowski";
            authors[4] = "Marcin Krzemiński";
            authors[5] = "Michał Wołyniec";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Aplikacja {appName}. Wersja {appVersion}.");
            Console.Write("Authors: ");
            foreach (string author in authors)
            {
                Console.Write(author+ "  "); 
            }
            Console.ResetColor();
            Column ToDo = new Column("To do");
            Column InProgress = new Column("In progress");
            Column Testing = new Column("Testing");
            Column Done = new Column("Done");

            Note A = new Note("A", "Pierwsza karteczka", Testing);
            Note B = new Note("B", "Druga karteczka", Testing);
            Note C = new Note("C", " ", Testing);
            Note D = new Note("D", " ", InProgress);
            Note F = new Note("F", " ", ToDo);
            Note H = new Note("H", " ", InProgress);
            Note I = new Note("I", " ", InProgress);
            Note K = new Note("K", " ", Done);
            Note S = new Note("S", " ", ToDo);

            var Kanban = new Dictionary<string, string>()
            {
                {F.name, ToDo.name},
                {S.name, ToDo.name},
                {D.name, InProgress.name},
                {H.name, InProgress.name},
                {I.name, InProgress.name},
                {A.name, Testing.name},
                {B.name, Testing.name},
                {C.name, Testing.name},
                {K.name, Done.name}
            };

            foreach (KeyValuePair<string, string> kvp in Kanban)
            {
                Console.WriteLine("Karteczka {0} jest w kolumnie {1}", kvp.Key, kvp.Value);
            }


            Console.ReadKey();
        }
    }

    public class Column
    {
        public string name;

        public Column(string name)
        {
            this.name = name;
        }
    }

    public class Note
    {
        public string name;
        private string description;
        private Column column;

        public Note(string name, string description, Column column)
        {
            this.name = name;
            this.description = description;
            this.column = column;
        }

    }
}
