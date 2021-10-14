using System;

namespace Sokoban
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int x = 10;
            int y = 10;

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                Console.CursorLeft = x;
                Console.CursorTop = y;
                Console.Write(" ");

                if (key.Key == ConsoleKey.UpArrow)
                {
                    y--; //X Y Z  У оо 
                }
                else
                if (key.Key == ConsoleKey.DownArrow)
                {
                    y++;
                }
                else
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    x--; 
                }
                else
                if (key.Key == ConsoleKey.RightArrow)
                {
                    x++;
                }

                Console.CursorLeft = x;
                Console.CursorTop = y;
                Console.Write("X");

                //Console.Write(key.KeyChar.ToString().ToUpper());                
            }

            Console.ReadLine();
        }
    }
}
