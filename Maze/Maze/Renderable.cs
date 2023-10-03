using System;

namespace Maze
{
    public abstract class Renderable
    {
        public Position position;
        protected char ToDraw;

        protected Position SetPosition(int newX, int newY)
        {
            return new Position { X = newX, Y = newY }; 
        }
        public void Draw()
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(ToDraw);
        }
    }
}
