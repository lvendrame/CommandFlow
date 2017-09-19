using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandFlow
{
    public partial class ConsoleMachine : ConsoleOption
    {
        private static Stack<ConsoleMachine> machines = new Stack<ConsoleMachine>();

        public static ConsoleMachine CurrentMachine
        {
            get
            {
                return machines.Peek();
            }
        }

        public static void Start(ConsoleSelect select, string description = "Untitled")
        {
            ConsoleMachine machine = new ConsoleMachine(description, select);
            machine.Execute();
        }

        public ConsoleMachine(string description, ConsoleSelect initialSelect)
        {
            this.Description = description;
            this.SelectedOption = initialSelect;
        }

        public ConsoleOption SelectedOption { get; private set; }

        public bool IsRunning { get; set; }

        public override void Execute()
        {
            machines.Push(this);
            this.IsRunning = true;
            while (this.IsRunning)
            {
                this.ExecuteSelectedOption();
            }
            machines.Pop();
        }

        private void ExecuteSelectedOption()
        {
            Console.Clear();
            this.SelectedOption.Execute();

            if (this.SelectedOption is ConsoleSelect)
            {
                ReadSelectedOption(this.SelectedOption as ConsoleSelect);
            }
            else
            {
                Previous();
            }
        }

        private void Previous()
        {
            this.SelectedOption = this.SelectedOption.Parent ?? this.SelectedOption;
        }

        private void ReadSelectedOption(ConsoleSelect consoleSelect)
        {
            Console.WriteLine();
            Console.Write(Messages.ChooseOption);

            string selectedOptionText = Console.ReadLine();

            int selectedOption = 0;

            if (int.TryParse(selectedOptionText, out selectedOption) && IsValidRange(consoleSelect, --selectedOption))
            {
                this.SelectedOption = consoleSelect.Options[selectedOption];
            }
            else if (selectedOption == consoleSelect.Options.Count)
            {
                this.Previous();
            }
            else if (selectedOption == 98)
            {
                this.Exit();
            }
            else
            {
                this.WrongOption(selectedOptionText, consoleSelect);
            }
        }

        private bool IsValidRange(ConsoleSelect consoleSelect, int selectedOption)
        {
            return selectedOption > -1 && selectedOption < consoleSelect.Options.Count;
        }

        private void WrongOption(string selectedOptionText, ConsoleSelect consoleSelect)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(Messages.WrongOption, selectedOptionText);
            Console.ResetColor();
            ReadSelectedOption(consoleSelect);
        }

        public void Exit()
        {
            if (machines.Count == 1)
            {
                Console.WriteLine();
                Console.WriteLine(Messages.ExitingApplication);
                Console.WriteLine();
            }

            this.IsRunning = false;
        }

        public void WriteTree()
        {
            TreeWriter.Write(this.SelectedOption);
        }
        
    }
}
