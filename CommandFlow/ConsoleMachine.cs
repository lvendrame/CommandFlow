using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandFlow
{
    /// <summary>
    /// Console State Machine is responsible to control application flow
    /// </summary>
    public class ConsoleMachine : ConsoleOption
    {
        /// <summary>
        /// Stack of machines
        /// </summary>
        private static Stack<ConsoleMachine> machines = new Stack<ConsoleMachine>();

        /// <summary>
        /// Current machine
        /// </summary>
        public static ConsoleMachine CurrentMachine
        {
            get
            {
                return machines.Peek();
            }
        }

        /// <summary>
        /// Create and start new console state machine
        /// </summary>
        /// <param name="select">Initial menu</param>
        /// <param name="description">Description</param>
        public static void Start(ConsoleSelect select, string description = "Untitled")
        {
            ConsoleMachine machine = new ConsoleMachine(description, select);
            machine.Execute();
        }

        /// <summary>
        /// Create a new console state machine
        /// </summary>
        /// <param name="description">Description</param>
        /// <param name="initialSelect">Initial menu</param>
        public ConsoleMachine(string description, ConsoleSelect initialSelect)
        {
            this.Description = description;
            this.SelectedOption = initialSelect;
        }

        /// <summary>
        /// Selected option
        /// </summary>
        public ConsoleOption SelectedOption { get; private set; }

        /// <summary>
        /// Indicate state machine are running
        /// </summary>
        public bool IsRunning { get; set; }

        /// <summary>
        /// Start state machine
        /// </summary>
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

        /// <summary>
        /// Execute option behavior
        /// </summary>
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

        /// <summary>
        /// Select previous option
        /// </summary>
        private void Previous()
        {
            this.SelectedOption = this.SelectedOption.Parent ?? this.SelectedOption;
        }

        /// <summary>
        /// Wait user input, verify if is a correct option and set option to selected
        /// </summary>
        /// <param name="consoleSelect"></param>
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

        /// <summary>
        /// Verify if selected option is valid in range
        /// </summary>
        /// <param name="consoleSelect">Current console select</param>
        /// <param name="selectedOption">Next selected option</param>
        /// <returns></returns>
        private bool IsValidRange(ConsoleSelect consoleSelect, int selectedOption)
        {
            return selectedOption > -1 && selectedOption < consoleSelect.Options.Count;
        }

        /// <summary>
        /// Write wrong option message
        /// </summary>
        /// <param name="selectedOptionText"></param>
        /// <param name="consoleSelect"></param>
        private void WrongOption(string selectedOptionText, ConsoleSelect consoleSelect)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(Messages.WrongOption, selectedOptionText);
            Console.ResetColor();
            ReadSelectedOption(consoleSelect);
        }

        /// <summary>
        /// Exite console machine
        /// </summary>
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

        /// <summary>
        /// Write menu tree
        /// </summary>
        public void WriteTree()
        {
            TreeWriter.Write(this.SelectedOption);
        }
        
    }
}
