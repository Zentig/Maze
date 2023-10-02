﻿using System;

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
