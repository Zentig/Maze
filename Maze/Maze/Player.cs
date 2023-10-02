﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Maze
{
    public class Player : Renderable
    {
        private List<Renderable> _map = new List<Renderable>();

        public Player(char symbol, List<Renderable> map)
        {
            ToDraw = symbol;
            _map = map;
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
                    if (CheckNewDestination(Direction.Left))
                    {
                        Clear(position.X, position.Y);
                        position = SetPosition(position.X - 1, position.Y);
                    }
                    break;
                case Direction.Right:
                    if (CheckNewDestination(Direction.Right))
                    {
                        Clear(position.X, position.Y);
                        position = SetPosition(position.X + 1, position.Y);
                    }
                    break;
                case Direction.Up:
                    if (CheckNewDestination(Direction.Up))
                    {
                        Clear(position.X, position.Y);
                        position = SetPosition(position.X, position.Y - 1);
                    }
                    break;
                case Direction.Down:
                    if (CheckNewDestination(Direction.Down))
                    {
                        Clear(position.X, position.Y);
                        position = SetPosition(position.X, position.Y + 1);
                    }
                    break;
            }
            Draw();
        }

        private bool CheckNewDestination(Direction currentDirection)
        {
            Position checkPosition = new Position { };

            switch (currentDirection)
            {
               case Direction.Right:
                   checkPosition.X = position.X + 1; 
                   checkPosition.Y = position.Y;
                   break;
               case Direction.Left:
                   checkPosition.X = position.X - 1;
                   checkPosition.Y = position.Y;
                   break;
               case Direction.Up:
                   checkPosition.X = position.X;
                   checkPosition.Y = position.Y - 1;
                   break;
               case Direction.Down:
                   checkPosition.X = position.X;
                   checkPosition.Y = position.Y + 1;
                   break;
            }
            foreach (var mapElement in _map)
            {
                if (mapElement is WallElement &&
                    mapElement.position.X == checkPosition.X &&
                    mapElement.position.Y == checkPosition.Y)
                {
                    return false;
                }
                if (mapElement is WinElement &&
                    mapElement.position.X == checkPosition.X &&
                    mapElement.position.Y == checkPosition.Y)
                {
                    Environment.Exit(0);
                }
            }
            return true;
        }
    }
} 

