using System;
using System.Collections.Generic;
using System.Text;

namespace Pinger.Tools
{
    public static class ConsoleTool
    {
        public static void WriteLineConsoleGreenMessage(string message)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void WriteLineConsoleWhiteMessage(string message)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
