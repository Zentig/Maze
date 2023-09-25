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
                x = value;
            } 
        }
        public int Y
        {
            get { return y; }
            set
            {
                y = value;
            }
        }
    }
}
