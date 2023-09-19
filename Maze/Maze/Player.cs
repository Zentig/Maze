using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class Player : Renderable
    {
        public Player(char symbol)
        {
            ToDraw = symbol;
            position = SetPosition(1, 1);
            Draw();
        }
        public override void Draw()
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(ToDraw);
        }
        public void Clear(int X, int Y)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
        }
        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    if (CanMoveNewDestination(Direction.Left))
                    {
                        Clear(position.X, position.Y);
                        position = SetPosition(position.X - 1, position.Y);
                    }
                    break;
                case Direction.Right:
                    if (CanMoveNewDestination(Direction.Right))
                    {
                        Clear(position.X, position.Y);
                        position = SetPosition(position.X + 1, position.Y);
                    }
                    break;
                case Direction.Up:
                    if (CanMoveNewDestination(Direction.Up))
                    {
                        Clear(position.X, position.Y);
                        position = SetPosition(position.X, position.Y - 1);
                    }
                    break;
                case Direction.Down:
                    if (CanMoveNewDestination(Direction.Down))
                    {
                        Clear(position.X, position.Y);
                        position = SetPosition(position.X, position.Y + 1);
                    }
                    break;
            }
            Draw();
        }
        public bool CanMoveNewDestination(Direction currentDirection)
        {
            Position wallCheckPosition = new Position { };

            switch (currentDirection)
            {
                case Direction.Right:
                    wallCheckPosition.X = position.X + 1; 
                    wallCheckPosition.Y = position.Y;
                    break;
                case Direction.Left:
                    wallCheckPosition.X = position.X - 1;
                    wallCheckPosition.Y = position.Y;
                    break;
                case Direction.Up:
                    wallCheckPosition.X = position.X;
                    wallCheckPosition.Y = position.Y - 1;
                    break;
                case Direction.Down:
                    wallCheckPosition.X = position.X;
                    wallCheckPosition.Y = position.Y + 1;
                    break;
            }
            foreach (Renderable wall in Game.Map)
            {
                if (wall.position.X == wallCheckPosition.X &&
                    wall.position.Y == wallCheckPosition.Y)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
