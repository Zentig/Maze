using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class CoinElement : Renderable
    {
        public CoinElement(char drawSymbol, int x, int y)
        {
            ToDraw = drawSymbol;
            position = SetPosition(x, y);
            Draw();
        }
    }
}
