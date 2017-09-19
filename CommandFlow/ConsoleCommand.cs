using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandFlow
{
    public class ConsoleCommand : ConsoleOption
    {
        public ConsoleCommand(string description, Action action)
        {
            this.Description = description;
            this.Action = action;
        }

        public Action Action { get; set; }

        public override void Execute()
        {
            this.Action();
        }
    }
}
