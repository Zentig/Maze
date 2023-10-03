using System;

namespace Maze
{
    public class WinElement : Renderable
    {
        public WinElement(char drawSymbol, int x, int y)
        {
            ToDraw = drawSymbol;
            position = SetPosition(x, y);
            Draw();
        }
    }
}
