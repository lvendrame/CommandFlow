using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandFlow
{
    public class ConsoleSelect: ConsoleOption
    {

        public ConsoleSelect(string description, string caption)
        {
            this.Caption = caption;
            this.Description = description;
            this.Options = new List<ConsoleOption>();
        }

        public string Caption { get; set; }

        public List<ConsoleOption> Options { get; set; }

        private int lastOption = 1;

        public override void Execute()
        {
            ConsoleUtils.WriteHeader(this.Caption, 118);
            Console.WriteLine();

            this.RenderOptions();
        }

        private void RenderOptions()
        {
            foreach (ConsoleOption option in this.Options)
            {
                option.Render();
            }

            if (this.Parent != null)
            {
                Console.WriteLine(Constants.OPTION, this.Options.Count + 1, Messages.PreviousOption);
            }

            Console.WriteLine(Constants.OPTION, 99, Messages.ExitOption);
        }

        public void AddOption(ConsoleOption option)
        {
            option.Number = lastOption++;
            option.Parent = this;
            this.Options.Add(option);
        }
    }
}
