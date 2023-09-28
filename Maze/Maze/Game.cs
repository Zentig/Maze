using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{ 
    public class Game
    {
        public static int MaxHeight = 21;
        public static int MaxWidth = 18;
        public static List<Renderable> Map = new List<Renderable>();
        public static char WALL_SYMBOL = '█';

        static void Main(string[] args)
        {
            Player player = new Player('X');
            SetOptions();
            GenerateMap();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyPressed = Console.ReadKey();
                    
                    switch (keyPressed.Key)
                    {
                        case ConsoleKey.UpArrow:
                            player.Move(Direction.Up);
                            RenderMap();
                            break;
                        case ConsoleKey.DownArrow:
                            player.Move(Direction.Down);
                            RenderMap();
                            break;
                        case ConsoleKey.RightArrow:
                            player.Move(Direction.Right);
                            RenderMap();
                            break;
                        case ConsoleKey.LeftArrow:
                            player.Move(Direction.Left);
                            RenderMap();
                            break;
                    }
                }
            }
            void SetOptions()
            {
                Console.CursorVisible = false;
                Console.SetWindowSize(35, 35);
            }
            void GenerateMap()
            {
                #region basicWalls
                for (int y = 0; y < MaxHeight; y++)
                {
                    Place(0, y, WALL_SYMBOL);
                    Place(MaxWidth - 1, y, WALL_SYMBOL);
                }
                for (int x = 0; x < MaxWidth; x++)
                {
                    Place(x, 0, WALL_SYMBOL);
                    Place(x, MaxHeight, WALL_SYMBOL);
                }
                #endregion
                MapBuilderX(2, 17, 1);
                MapBuilderY(2, 11, 2);
                MapBuilderX(4, 9, 3);
                MapBuilderX(4, 9, 4);
                MapBuilderX(4, 5, 5);
                MapBuilderX(8, 9, 5);
                MapBuilderX(1, 3, 13);
                MapBuilderY(6, 18, 4);
                MapBuilderX(1, 5, 19);
                MapBuilderY(7, 19, 7);
                MapBuilderY(6, 19, 9);
                MapBuilderY(3, 19, 11);
                MapBuilderY(2, 9, 13);
                MapBuilderY(4, 12, 15);
                MapBuilderY(12, 16, 13);
                MapBuilderY(16, 18, 15);
                MapBuilderX(12, 15, 19);
                Place(6, 7, WALL_SYMBOL);
                Place(5, 9, WALL_SYMBOL);
                Place(6, 11, WALL_SYMBOL);
                Place(5, 13, WALL_SYMBOL);
                Place(5, 14, WALL_SYMBOL);
                Place(6, 16, WALL_SYMBOL);
                Place(6, 17, WALL_SYMBOL);
                Place(8, 19, WALL_SYMBOL);
                Place(12, 9, WALL_SYMBOL);
                Place(14, 12, WALL_SYMBOL);
                Place(14, 16, WALL_SYMBOL);
            }
            void RenderMap()
            {
                foreach (WallElement element in Map)
                {
                    element.Draw();
                }
            }
            void Place(int x, int y, char drawSymbol)
            {
                if (!Map.Contains(new WallElement(drawSymbol, x, y)))
                {
                    WallElement wallElement = new WallElement(drawSymbol, x, y);
                    Map.Add(wallElement);
                }
            }
            void MapBuilderX(int minX, int maxX, int y)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    Place(x, y, WALL_SYMBOL);
                }
            }
            void MapBuilderY(int minY, int maxY, int x)
            {
                for (int y = minY; y < maxY; y++)
                {
                    Place(x, y, WALL_SYMBOL);
                }
                Place(x, maxY, WALL_SYMBOL);
            }
        }
    }
}
