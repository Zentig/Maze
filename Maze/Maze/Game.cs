using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class Game
    {
        public static string[] Map =
        { "XXXXXXXXXXXX",
          "XXX  XXXXXXX",
          "XXX  XXXXXXX",
          "XXX       XX",
          "XXXXXXXX  XX",
          "XXXXXXXX  XX",
          "XXXXXXXX  XX",
          "XXXXXXXX  XX",
          "XXXXXXXX  XX",
          "XXX       XX",
          "XXX  XXXXXXX",
          "XXXXXXXXXXXX",
        };

        static void Main(string[] args)
        {
            InitMap();
            Console.ReadKey();

            void GameLoop()
            {
                while (true)
                {
                
                }
            }
            void InitMap()
            {
                foreach (var item in Map)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
