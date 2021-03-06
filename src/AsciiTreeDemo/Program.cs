﻿using System;
using System.IO;
using System.Text;
using AsciiTreeDemo.Helpers;

namespace AsciiTreeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var asciiTreeHelper = new AsciiTreeHelper();
            // Get the list of nodes
            var topLevelNodes = Mock.CreateNodeList(3, 5);

            asciiTreeHelper.MaxPrintDeep = 2;
            var sb = new StringBuilder();
            foreach (var topLevelNode in topLevelNodes)
            {
                asciiTreeHelper.ProcessNode(topLevelNode, "", sb, 0);
            }
            Console.WriteLine(sb);
            Console.Read();
        }
    }
}
