using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class Player : Renderable
    {
        public Position Position;
        public char ToDraw;

        public Player(char symbol)
        {
            ToDraw = symbol;
            Position = SetPosition(1, 1);
            Draw();
        }
        public override void Draw()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(ToDraw);
        }
        public override void Clear(int X, int Y)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
        }
        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    Clear(Position.X, Position.Y);
                    Position = SetPosition(Position.X - 1, Position.Y);
                    break;
                case Direction.Right:
                    Clear(Position.X, Position.Y);
                    Position = SetPosition(Position.X + 1, Position.Y);
                    break;
                case Direction.Up:
                    Clear(Position.X, Position.Y);
                    Position = SetPosition(Position.X, Position.Y - 1);
                    break;
                case Direction.Down:
                    Clear(Position.X, Position.Y);
                    Position = SetPosition(Position.X, Position.Y + 1);
                    break;
            }
            Draw();
        }
        
    }
}
