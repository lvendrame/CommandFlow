using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandFlow
{
    public abstract class ConsoleOption
    {
        public int SelectedItem { get; set; }

        public int Number { get; set; }

        public string Description { get; set; }

        public ConsoleOption Parent { get; set; }

        public void Render()
        {
            Console.WriteLine(Constants.OPTION, this.Number, this.Description);
        }

        public abstract void Execute();
    }
}
