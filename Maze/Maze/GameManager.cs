using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Maze
{
    public class GameManager
    {
        public const int MAX_HEIGHT = 21;
        public const int MAX_WIDTH = 18;
        public const char WALL_SYMBOL = '█';
        public const char PLAYER_SYMBOL = 'X';
        public const char WIN_SYMBOL = 'W';
        public const char COIN_SYMBOL = '$';
        public const int START_TIME = 30; // *in seconds*

        public List<Renderable> Map = new List<Renderable>();
        public int Coins { get; set; }

        Player player;
        MapBuilder mb;
        Stopwatch sw = new Stopwatch();

        public void Start()
        {
            player = new Player(PLAYER_SYMBOL, Map);
            player.OnCoinTriggered += CheckCoins;
            mb = new MapBuilder(Map, WALL_SYMBOL, WIN_SYMBOL, COIN_SYMBOL, MAX_HEIGHT, MAX_WIDTH);
            mb.GenerateMap();
            Coins = 0;

            SetOptions();
            GameLoop();
        }

        void GameLoop()
        {
            sw.Start();

            while (true)
            {
                CheckTime();

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyPressed = Console.ReadKey();

                    switch (keyPressed.Key)
                    {
                        case ConsoleKey.UpArrow:
                            player.Move(Direction.Up);
                            mb.RenderMap();
                            break;
                        case ConsoleKey.DownArrow:
                            player.Move(Direction.Down);
                            mb.RenderMap();
                            break;
                        case ConsoleKey.RightArrow:
                            player.Move(Direction.Right);
                            mb.RenderMap();
                            break;
                        case ConsoleKey.LeftArrow:
                            player.Move(Direction.Left);
                            mb.RenderMap();
                            break;
                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;
                    }
                }
            }
        }
        void SetOptions()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(35, 35);
        }
        void CheckTime()
        {
            int leftTime = (int)(START_TIME - (sw.ElapsedMilliseconds / 1000));

            Console.SetCursorPosition(20, 1);
            Console.WriteLine($"Time: {leftTime} ");

            if (leftTime <= 0)
            {
                sw.Stop();
                Environment.Exit(0);
            }
        }
        public void CheckCoins(CoinElement coin)
        {
            Map.Remove(coin);
            player.ReloadMap(Map);
            Coins++;
            Console.SetCursorPosition(20, 3);
            Console.Write($"Coins: {Coins} ");
        }
    }
}
