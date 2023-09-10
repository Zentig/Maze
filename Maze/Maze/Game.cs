using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{ 
    public class Game
    {
        public static int MaxHeight = 45;
        public static int MaxWidth = 45;
        
        static void Main(string[] args)
        {
            Player player = new Player('X');
            Console.ReadKey();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyPressed = Console.ReadKey();
                    
                    switch (keyPressed.Key)
                    {
                        case ConsoleKey.UpArrow:
                            player.Move(Direction.Up);
                            break;
                        case ConsoleKey.DownArrow:
                            player.Move(Direction.Down);
                            break;
                        case ConsoleKey.RightArrow:
                            player.Move(Direction.Right);
                            break;
                        case ConsoleKey.LeftArrow:
                            player.Move(Direction.Left);
                            break;
                    }
                }
            }
        }
    }
}
