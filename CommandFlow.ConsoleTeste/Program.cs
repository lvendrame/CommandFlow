using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace CommandFlow.ConsoleTeste
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleSelect main = new ConsoleSelect("Main", "Main Menu");

            ConsoleSelect first = new ConsoleSelect("First", "First menu");
            first.AddOption(new ConsoleCommand("Command One", () => { Console.WriteLine("Command One"); Console.ReadKey(); }));
            first.AddOption(new ConsoleCommand("Command Two", () => { Console.WriteLine("Command Two"); Console.ReadKey(); }));
            first.AddOption(new ConsoleCommand("Command Three", () => { Console.WriteLine("Command Three"); Console.ReadKey(); }));
            first.AddOption(new ConsoleCommand("Command Four", () => { Console.WriteLine("Command Four"); Console.ReadKey(); }));            
            first.AddOption(new ConsoleCommand("Write Tree", () => { ConsoleMachine.CurrentMachine.WriteTree(); }));


            ConsoleSelect second = new ConsoleSelect("Second", "Second menu");

            ConsoleSelect secondOne = new ConsoleSelect("One", "Second menu - [1]");
            secondOne.AddOption(new ConsoleCommand("My method", MyMethod));
            secondOne.AddOption(new ConsoleCommand("Force exit", () => ConsoleMachine.CurrentMachine.Exit()));

            second.AddOption(secondOne);
            second.AddOption(new ConsoleSelect("Two", "Second menu - [2]"));
            second.AddOption(new ConsoleSelect("Three", "Second menu - [3]"));

            ConsoleSelect third = new ConsoleSelect("Third", "Third menu");
            third.AddOption(CreateSubMachine());

            ConsoleSelect fourth = new ConsoleSelect("Fourth", "Fourth menu");

            main.AddOption(first);
            main.AddOption(second);
            main.AddOption(third);
            main.AddOption(fourth);

            ConsoleMachine.Start(main);
        }

        private static ConsoleOption CreateSubMachine()
        {
            ConsoleSelect main = new ConsoleSelect("Sub-Machine", "Sub-Machine Menu");

            main.AddOption(new ConsoleCommand("SM - One", () => { Console.WriteLine("Command SM - One"); Console.ReadKey(); }));
            main.AddOption(new ConsoleCommand("SM - Two", () => { Console.WriteLine("Command SM - Two"); Console.ReadKey(); }));
            main.AddOption(new ConsoleCommand("SM - Three", () => { Console.WriteLine("Command SM - Three"); Console.ReadKey(); }));
            main.AddOption(new ConsoleCommand("SM - Four", () => { Console.WriteLine("Command SM - Four"); Console.ReadKey(); }));

            return new ConsoleMachine("Sub-Machine", main);
        }

        public static void MyMethod()
        {
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine(new string((char)(i + 47), i));
            }
            Console.ReadKey();
        }
    }
}
