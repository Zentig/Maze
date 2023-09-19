using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class WallElement : Renderable
    {
        public WallElement(char drawSymbol, int x, int y)
        {
            ToDraw = drawSymbol;
            position = SetPosition(x, y);
            Draw();
        }
        public override void Draw()
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(ToDraw);
        }
    }
}
