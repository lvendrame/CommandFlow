using System;

namespace CommandFlow
{
    /// <summary>
    /// Tree writer
    /// </summary>
    public class TreeWriter
    {

        /// <summary>
        /// Write menu tree
        /// </summary>
        /// <param name="initialNode"></param>
        public static void Write(ConsoleOption initialNode)
        {
            Console.Clear();
            ConsoleUtils.WriteHeader(Messages.Tree, 118);
            ConsoleOption head = GetHead(initialNode);

            WriteNode(head, -1);
            Console.ReadKey();
        }

        /// <summary>
        /// Het head of tree
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static ConsoleOption GetHead(ConsoleOption node)
        {
            return (node.Parent == null) ? node : GetHead(node.Parent);
        }

        /// <summary>
        /// Write node
        /// </summary>
        /// <param name="node">Node</param>
        /// <param name="deep">Deep</param>
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

        /// <summary>
        /// Render node on console
        /// </summary>
        /// <param name="node">Node</param>
        /// <param name="deep">Deep</param>
        private static void RenderNode(ConsoleOption node, int deep)
        {
            string tabs = new string((char)9, deep);//TAB Character
            Console.WriteLine("{0}[{1}] - {2}", tabs, node.Number, node.Description);
        }


    }
}
