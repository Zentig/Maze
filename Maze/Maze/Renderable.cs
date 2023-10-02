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
        public abstract void Draw();
    }
}
