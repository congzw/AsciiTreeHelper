using System.Collections.Generic;

namespace AsciiTreeDemo.Helpers
{
    public class Node
    {
        public string Name { get; set; }
        public List<Node> Children { get; } = new List<Node>();
    }
}