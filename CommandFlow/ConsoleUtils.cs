using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandFlow
{
    public class ConsoleUtils
    {
        public const char SPACE = (char)32;

        /// <summary>
        /// Writer header
        /// </summary>
        /// <param name="caption">Caption</param>
        /// <param name="columns">Console columns</param>
        /// <param name="decorator">Header decorator</param>
        public static void WriteHeader(string caption, int columns, char decorator = '*')
        {
            string decoratorString = new String(decorator, columns);

            Console.WriteLine(decoratorString);
            WriteCenterText(caption, columns, new string(decorator, 1));
            Console.WriteLine(decoratorString);
        }

        /// <summary>
        /// Write centralized text
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="columns">Console columns</param>
        /// <param name="decorator">Decorator</param>
        public static void WriteCenterText(string text, int columns, string decorator = "*")
        {
            int countSpaces = ((columns - text.Length) / 2) - decorator.Length;
            string spaces = new string(SPACE, countSpaces);

            Console.WriteLine("{0}{1}{2}{1}{0}", decorator, spaces, text);
        }

    }
}
