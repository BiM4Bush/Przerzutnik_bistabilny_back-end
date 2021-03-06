﻿using System;
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
            GetAppInfo();

            Column ToDo = new Column("To do");
            Column InProgress = new Column("In progress");
            Column Testing = new Column("Testing");
            Column Done = new Column("Done");

            Note A = new Note("A", "Pierwsza karteczka");
            Note B = new Note("B", "Druga karteczka");
            Note C = new Note("C", " ");
            Note D = new Note("D", " ");
            Note F = new Note("F", " ");
            Note H = new Note("H", " ");
            Note I = new Note("I", " ");
            Note K = new Note("K", " ");
            Note S = new Note("S", " ");
            
            var Kanban = new Dictionary<Note, Column>();

            Person Steve = new Person("Steve Jobs");

            var WorkPlan = new Dictionary<Note, Person>();

            StickPersonToNote(WorkPlan, A, Steve);
            StickPersonToNote(WorkPlan, A, Steve);

            AddNoteToColumn(Kanban, A, ToDo);
            AddNoteToColumn(Kanban, B, ToDo);
            AddNoteToColumn(Kanban, C, ToDo);
            AddNoteToColumn(Kanban, D, ToDo);
            AddNoteToColumn(Kanban, F, ToDo);
            AddNoteToColumn(Kanban, H, ToDo);
            AddNoteToColumn(Kanban, I, ToDo);
            AddNoteToColumn(Kanban, K, ToDo);
            AddNoteToColumn(Kanban, S, ToDo);
            foreach (KeyValuePair<Note, Column> kvp in Kanban)
            {
                Console.WriteLine("Note {0} is in Column {1}", kvp.Key.name, kvp.Value.name);
            }

            Console.WriteLine("Looking if A note was moved to Done column");

            ChangeColumnForNote(Kanban, A, Done);

            foreach (KeyValuePair<Note, Column> kvp in Kanban)
            {
                Console.WriteLine("Note {0} is in Column {1}", kvp.Key.name, kvp.Value.name);
            }

            Console.WriteLine("Looking if A be removed from Kanban table");

            RemoveNoteFromColumn(Kanban, A);

            foreach (KeyValuePair<Note, Column> kvp in Kanban)
            {
                Console.WriteLine("Note {0} is in Column {1}", kvp.Key.name, kvp.Value.name);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press any key to exit console application");
            Console.ReadKey();
        }
        public static void GetAppInfo()
        {
            string appName = "Kanban table";
            int appVersion = 1;
            string[] authors = new string[6];
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
                Console.Write(author + "  ");
            }
            Console.ResetColor();
        }
        public static void AddNoteToColumn(Dictionary<Note, Column> dict , Note key, Column value)
        {
            dict.Add(key, value);
        }
        public static void RemoveNoteFromColumn(Dictionary<Note, Column> dict, Note key)
        {
            dict.Remove(key);
        }
        public static void ChangeColumnForNote(Dictionary<Note, Column> dict, Note key, Column value)
        {
            RemoveNoteFromColumn(dict, key);
            dict.Add(key, value);
        }
        public static void StickPersonToNote(Dictionary<Note, Person> dict, Note key, Person value)
        {
            if(!dict.ContainsKey(key))
            {
                dict.Add(key, value);
            }
            else
            {
                Console.WriteLine("Someone got this already");
            }

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
        
        public Note(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

    }
    public class Person
    {
        public string nick;

        public Person(string nick)
        {
            this.nick = nick;
        }
    }

}

