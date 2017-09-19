using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandFlow
{
    /// <summary>
    /// Option to show on console
    /// </summary>
    public abstract class ConsoleOption
    {
        /// <summary>
        /// Number that represents this option
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Option description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Parent
        /// </summary>
        public ConsoleOption Parent { get; set; }

        /// <summary>
        /// Render option on console
        /// </summary>
        public void Render()
        {
            Console.WriteLine(Constants.OPTION, this.Number, this.Description);
        }

        /// <summary>
        /// That method is called when this option is selected
        /// </summary>
        public abstract void Execute();
    }
}
