using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AsciiTreeDemo.Helpers
{
    public class AsciiTreeHelper
    {
        public const string _cross = " ├─";
        public const string _corner = " └─";
        public const string _vertical = " │ ";
        public const string _space = "   ";

        public int MaxPrintDeep { get; set; }

        public void ProcessNode(Node node, string indent, StringBuilder sb, int currentDeep)
        {
            sb.AppendLine(node.Name);
            var numberOfChildren = node.Children.Count;
            for (var i = 0; i < numberOfChildren; i++)
            {
                var child = node.Children[i];
                var isLast = (i == (numberOfChildren - 1));
                ProcessChildNode(child, indent, isLast, sb, currentDeep + 1);
            }
        }

        private void ProcessChildNode(Node node, string indent, bool isLast, StringBuilder sb, int currentDeep)
        {
            if (MaxPrintDeep != 0 && currentDeep > MaxPrintDeep)
            {
                return;
            }
            // Print the provided pipes/spaces indent
            sb.Append(indent);

            // Depending if this node is a last child, print the
            // corner or cross, and calculate the indent that will
            // be passed to its children
            if (isLast)
            {
                sb.Append(_corner);
                indent += _space;
            }
            else
            {
                sb.Append(_cross);
                indent += _vertical;
            }

            ProcessNode(node, indent, sb, currentDeep);
        }

        public string GetCurrentTree()
        {
            var nodes = new List<Node>();
            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var directories = Directory.GetDirectories(currentDirectory);
            foreach (var directory in directories)
            {
                var directoryInfo = new DirectoryInfo(directory);
                var node = new Node();
                AppendChildNode(node, directoryInfo);
                nodes.Add(node);
            }

            var sb = new StringBuilder();
            foreach (var node in nodes)
            {
                ProcessNode(node, "", sb, 0);
            }
            return sb.ToString();
        }

        private void AppendChildNode(Node node, DirectoryInfo directoryInfo)
        {
            node.Name = directoryInfo.Name;

            //child files
            foreach (var fileInfo in directoryInfo.GetFiles().OrderBy(x => x.Name))
            {
                var childFileNode = new Node();
                childFileNode.Name = fileInfo.Name;
                node.Children.Add(childFileNode);
            }

            //child dir
            foreach (var childDir in directoryInfo.GetDirectories().OrderBy(x => x.Name))
            {
                var childDirNode = new Node();
                node.Children.Add(childDirNode);
                AppendChildNode(childDirNode, childDir);
            }
        }
    }
}