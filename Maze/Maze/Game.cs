using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{ 
    public class Game
    {
        public static int MaxHeight = 10;
        public static int MaxWidth = 25;
        public static List<Renderable> Map = new List<Renderable>();

        static void Main(string[] args)
        {
            Player player = new Player('X');
            SetOptions();
            GenerateMap('/');

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
            void SetOptions()
            {
                Console.CursorVisible = false;
                Console.SetWindowSize(MaxWidth, MaxHeight);
            }
            void GenerateMap(char wallSymbol)
            {
                for (int i = 0; i < MaxHeight; i++)
                {
                    WallElement tempUpperWall = new WallElement(wallSymbol, i, 0);
                    WallElement tempDownWall = new WallElement(wallSymbol, i, MaxHeight - 1);

                    if (!Map.Contains(tempUpperWall)) { Map.Add(tempUpperWall); }
                    if (!Map.Contains(tempUpperWall)) { Map.Add(tempDownWall); }
                }
                for (int i = 0; i < MaxWidth; i++)
                {
                    WallElement tempLeftWall = new WallElement(wallSymbol, 0, i); 
                    WallElement tempRightWall = new WallElement(wallSymbol, MaxWidth - 1, i);

                    if (!Map.Contains(tempLeftWall)) { Map.Add(tempLeftWall); }
                    if (!Map.Contains(tempRightWall)) { Map.Add(tempRightWall); }
                }
            }
        }
    }
}
