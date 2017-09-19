using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandFlow
{
    /// <summary>
    /// Represents an option that execute an command
    /// </summary>
    public class ConsoleCommand : ConsoleOption
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="description">Option description</param>
        /// <param name="action">Action to execute</param>
        public ConsoleCommand(string description, Action action)
        {
            this.Description = description;
            this.Action = action;
        }

        /// <summary>
        /// Action that will execute
        /// </summary>
        public Action Action { get; set; }

        /// <summary>
        /// Call Action
        /// </summary>
        public override void Execute()
        {
            this.Action();
        }
    }
}
