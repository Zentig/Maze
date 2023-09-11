using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public abstract class Renderable
    {
        protected Position Position { get; set; }
        protected char ToDraw;

        protected Position SetPosition(int newX, int newY)
        {
            return new Position { X = newX, Y = newY }; 
        }
        public abstract void Draw();

        public abstract void Clear(int X, int Y);
    }
}
