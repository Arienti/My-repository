using System; //the System is name of the Unit 
using System.Collections.Generic;
using System.Threading;

namespace Snake
{
    public class AppleCoord //scheme 
    {
        public bool ImEating = false;
        public int x; 
        public int y;
    }

    public class TailSegmentCoord //scheme 
    {        
        public int x;
        public int y;
    }

    class Program
    {
        static int widht = 80;
        static int height = 40;
        static int appleSize = 50;
        static int eatedApplesCount = 0;
        //{} () [] <>
        //we use List of objects of class AppleCoord
        static List<AppleCoord> apples = new List<AppleCoord>();
        
        static List<TailSegmentCoord> tail = new List<TailSegmentCoord>();
        private static void Main(string[] args)
        {
            Random r = new Random();
            for(int i=0; i < appleSize; i++ )
            {
                AppleCoord a = new AppleCoord();
                a.x = r.Next(widht);
                a.y = r.Next(height);
                apples.Add(a);

                Console.CursorLeft = a.x;
                Console.CursorTop = a.y;
                Console.Write("0");
            }

            TailSegmentCoord head = new TailSegmentCoord();
            head.x = 10;
            head.y = 10;
            tail.Add(head);

            ConsoleKeyInfo key = new ConsoleKeyInfo();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    key = Console.ReadKey();
                }

                Console.CursorLeft = tail[tail.Count - 1].x;
                Console.CursorTop = tail[tail.Count - 1].y;
                Console.Write(" ");

                TailSegmentCoord storePrevSegment = new TailSegmentCoord();
                storePrevSegment.x = tail[0].x;
                storePrevSegment.y = tail[0].y;

                for (int i = 1; i < tail.Count; i++)
                {
                    TailSegmentCoord storeCurrentSegment = new TailSegmentCoord();
                    storeCurrentSegment.x = tail[i].x;
                    storeCurrentSegment.y = tail[i].y;

                    tail[i].x = storePrevSegment.x;
                    tail[i].y = storePrevSegment.y;
                    storePrevSegment = storeCurrentSegment;
                }


                //we check where snake go
                if (key.Key == ConsoleKey.UpArrow)
                {
                    tail[0].y--; //X Y Z  У оо 
                }
                else
                if (key.Key == ConsoleKey.DownArrow)
                {
                    tail[0].y++;
                }
                else
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    tail[0].x--;
                }
                else
                if (key.Key == ConsoleKey.RightArrow)
                {
                    tail[0].x++;
                }
                //at this stage our snake is make new step
                
                for (int i = 0; i < appleSize; i++)
                {
                    if ((apples[i].x == tail[0].x) && (apples[i].y == tail[0].y))
                    {
                        apples[i].ImEating = true;
                        eatedApplesCount++;
                        //0,1,2
                        //Count = 1, index of first element is 0
                        //Count = 2, index of first element is 0, index of second element is 1
                        //tail.Count - 1 is always last element of list (tail.LastIndexOf)                        
                        TailSegmentCoord tailSegment = new TailSegmentCoord();
                        tailSegment.x = tail[tail.Count - 1].x;
                        tailSegment.y = tail[tail.Count - 1].y;
                        tail.Add(tailSegment);
                    }
                }

                if (tail[0].x < 0)
                {
                    tail[0].x = widht;
                }

                if (tail[0].x > widht)
                {
                    tail[0].x = 0;
                }

                if (tail[0].y < 0)
                {
                    tail[0].y = height;
                }

                if (tail[0].y > height)
                {
                    tail[0].y = 0;
                }

                for (int i = 0; i < tail.Count; i++)
                {
                    if (i == 0)
                    {
                        Console.CursorLeft = tail[i].x;
                        Console.CursorTop = tail[i].y;
                        Console.Write("X");
                    }
                    else
                    {
                        Console.CursorLeft = tail[i].x;
                        Console.CursorTop = tail[i].y;
                        Console.Write("0");
                    }
                }

                Console.CursorLeft = 0;
                Console.CursorTop = 41;
                Console.Write(eatedApplesCount);

                if (eatedApplesCount == appleSize)
                {
                    Console.Write("Game Over");
                    break; //while (true) is break now 
                }
                Thread.Sleep(100);
                //Console.Write(key.KeyChar.ToString().ToUpper());                
            }

            Console.ReadLine();
        }
    }
}
