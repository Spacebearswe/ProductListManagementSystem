using System;
using System.Collections.Generic;
using System.Text;

namespace ProductListManagementSystem
{
    public static class ColoredText
    {
        // / <summary>
        // / Writes a message to the console in the specified color.
        // / </summary>
        // / <param name="message">The message to write.</param>
        // / <param name="color">The color to use.</param>
        public static void WriteLine(string message, ConsoleColor color)
        {
            var prev = Console.ForegroundColor;
            try
            {
                Console.ForegroundColor = color;
                Console.WriteLine(message);
            }
            finally
            {
                Console.ForegroundColor = prev;
            }
        }

        public static void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
