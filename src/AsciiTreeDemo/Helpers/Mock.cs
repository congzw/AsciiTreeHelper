using System.Collections.Generic;

namespace AsciiTreeDemo.Helpers
{
    public class Mock
    {
        public static List<Node> CreateNodeList(int appendCount, int maxDeep)
        {
            var nodes = new List<Node>();
            for (int i = 0; i < maxDeep; i++)
            {
                var node = new Node();
                node.Name = "Node" + i;
                nodes.Add(node);
                AppendChild(node, appendCount,0, maxDeep);
            }
            return nodes;
        }

        private static void AppendChild(Node node, int appendCount, int currentDeep, int maxDeep)
        {
            if (currentDeep > maxDeep)
            {
                return;
            }

            for (int i = 0; i < appendCount; i++)
            {
                var child = new Node() {Name = node.Name + "-" + i};
                node.Children.Add(child);
                AppendChild(child, appendCount, currentDeep + 1, maxDeep);
            }
        }
    }
}
