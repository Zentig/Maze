using System;

namespace Maze
{
    public struct Position
    {
        private int x;
        private int y;

        public int X 
        {
            get { return x; }
            set 
            {
                if (value < Game.MaxWidth && value > 0)
                {
                    x = value;
                }
            } 
        }
        public int Y
        {
            get { return y; }
            set
            {
                if (value > 0 && value <= Game.MaxHeight)
                {
                    y = value;
                }
            }
        }
    }
}
