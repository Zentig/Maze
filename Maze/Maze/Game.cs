using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{ 
    public class Game
    {
        public static int MaxHeight = 25;
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
            void GenerateMap(char wallSymbol)
            {
                for (int i = 0; i < MaxHeight; i++)
                {
                    WallElement tempUpperWall = null;
                    WallElement tempDownWall = null;

                    if (!Map.Contains(tempUpperWall)) 
                    {
                        tempUpperWall = new WallElement(wallSymbol, i, 0);
                        Map.Add(tempUpperWall); 
                    }
                    if (!Map.Contains(tempDownWall)) 
                    {
                        tempDownWall = new WallElement(wallSymbol, i, MaxHeight);
                        Map.Add(tempDownWall); 
                    }
                }
                for (int i = 0; i < MaxWidth; i++)
                {
                    WallElement tempRightWall = null;
                    WallElement tempLeftWall = null;

                    if (!Map.Contains(tempLeftWall)) 
                    { 
                        tempLeftWall = new WallElement(wallSymbol, 0, i); 
                        Map.Add(tempLeftWall); 
                    }
                    if (!Map.Contains(tempRightWall)) 
                    {
                        tempRightWall = new WallElement(wallSymbol, MaxWidth, i);
                        Map.Add(tempRightWall); 
                    }
                }
                Map.Add(new WallElement(wallSymbol, 4, 4));
                Map.Add(new WallElement(wallSymbol, 2, 8));
                Map.Add(new WallElement(wallSymbol, 5, 9));
                Map.Add(new WallElement(wallSymbol, 14, 4));
                Map.Add(new WallElement(wallSymbol, 3, 21));
                Map.Add(new WallElement(wallSymbol, 12, 19));
            }
            void RenderMap()
            {
                foreach (WallElement element in Map)
                {
                    element.Draw();
                }
            }
        }
    }
}
