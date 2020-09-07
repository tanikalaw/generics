using Generics.Models;
using Generics.WithGenerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ReadLine();

            RunTextFileStorage();

            Console.WriteLine();
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();

        }

        private static void PopulateList(List<Person> people, List<LogEntry> logs) 
        {
            people.Add(new Person { Firstname = "Rj",  Lastname = "Samonte" });
            people.Add(new Person { Firstname = "George", Lastname = "Bush" , IsAlive = false });
            people.Add(new Person { Firstname = "Kim",  Lastname = "Porter" });

            logs.Add(new LogEntry { Message = "You're way too shiny", ErrorCode = 101 });
            logs.Add(new LogEntry { Message = "You're way too grumpy", ErrorCode = 102 });
            logs.Add(new LogEntry { Message = "You're way too sad", ErrorCode = 103 });
        }

        private static void RunTextFileStorage()
        {
            List<Person> people = new List<Person>();
            List<LogEntry> logs = new List<LogEntry>();

            string peopleFile = @"C:\Temp\people.csv";
            string logFile = @"C:\Temp\log.csv";

            PopulateList(people, logs);

            GenericTextFileProcessor.SaveToTextFile<Person>(people, peopleFile);
            GenericTextFileProcessor.SaveToTextFile<LogEntry>(logs, logFile);

            var newPeople = GenericTextFileProcessor.LoadFromtTextFile<Person>(peopleFile);

            foreach (var item in newPeople)
            {
                Console.WriteLine($"{item.Firstname } {item.Lastname } (IsAlive {item.IsAlive })");
            }

            var newLogs = GenericTextFileProcessor.LoadFromtTextFile<LogEntry>(logFile);

            foreach (var log in newLogs)
            {
                Console.WriteLine($"{log.ErrorCode }: {log.Message } at  {log.TimeOfEvent.ToShortTimeString() }");
            }
        }
    }
}
