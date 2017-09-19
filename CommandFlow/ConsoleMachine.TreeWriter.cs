using System;

namespace CommandFlow
{
    public partial class ConsoleMachine
    {
        public class TreeWriter
        {

            public static void Write(ConsoleOption initialNode)
            {
                Console.Clear();
                ConsoleUtils.WriteHeader(Messages.Tree, 118);
                ConsoleOption head = GetHead(initialNode);

                WriteNode(head, -1);
                Console.ReadKey();
            }

            public static ConsoleOption GetHead(ConsoleOption node)
            {
                return (node.Parent == null) ? node : GetHead(node.Parent);
            }

            private static void WriteNode(ConsoleOption node, int deep)
            {
                deep++;
                RenderNode(node, deep);

                if (node is ConsoleSelect)
                {
                    ConsoleSelect select = node as ConsoleSelect;
                    foreach (ConsoleOption item in select.Options)
                    {
                        WriteNode(item, deep);
                    }
                }
            }

            private static void RenderNode(ConsoleOption node, int deep)
            {
                string tabs = new string((char)9, deep);
                Console.WriteLine("{0}[{1}] - {2}", tabs, node.Number, node.Description);
            }

        }

        
    }
}
