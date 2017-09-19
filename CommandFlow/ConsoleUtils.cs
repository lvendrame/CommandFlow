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

        public static void WriteHeader(string caption, int columns, char decorator = '*')
        {
            string decoratorString = new String(decorator, columns);

            Console.WriteLine(decoratorString);
            WriteCenterText(caption, columns, new string(decorator, 1));
            Console.WriteLine(decoratorString);
        }

        public static void WriteCenterText(string text, int columns, string decorator = "*")
        {
            int countSpaces = ((columns - text.Length) / 2) - decorator.Length;
            string spaces = new string(SPACE, countSpaces);

            Console.WriteLine("{0}{1}{2}{1}{0}", decorator, spaces, text);
        }

    }
}
