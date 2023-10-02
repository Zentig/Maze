using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Maze
{
    enum BuildType
    {
        DefaultWall,
        WinWall
    }
    public class MapBuilder
    {
        List<Renderable> _map;
        readonly char _wallSymbol;
        readonly char _winElementSymbol;
        public readonly int MaxHeight, MaxWidth;

        public MapBuilder(List<Renderable> map, 
            char wallSymbol,
            char winElementSymbol,
            int maxHeight, 
            int maxWidth)
        {
            _map = map;
            _wallSymbol = wallSymbol;
            _winElementSymbol = winElementSymbol;
            MaxHeight = maxHeight;
            MaxWidth = maxWidth;
        }
        public void GenerateMap()
        {
            #region basicWalls
            for (int y = 0; y < MaxHeight; y++)
            {
                Place(0, y, _wallSymbol, BuildType.DefaultWall);
                Place(MaxWidth - 1, y, _wallSymbol, BuildType.DefaultWall);
            }
            for (int x = 0; x < MaxWidth; x++)
            {
                Place(x, 0, _wallSymbol, BuildType.DefaultWall);
                Place(x, MaxHeight, _wallSymbol, BuildType.DefaultWall);
            }
            #endregion
            #region otherWalls
            MapBuilderX(2, 17, 1);
            MapBuilderY(2, 11, 2);
            MapBuilderX(4, 9, 3);
            MapBuilderX(4, 9, 4);
            MapBuilderX(4, 5, 5);
            MapBuilderX(8, 9, 5);
            MapBuilderX(1, 3, 13);
            MapBuilderY(6, 18, 4);
            MapBuilderX(1, 5, 19);
            MapBuilderY(7, 19, 7);
            MapBuilderY(6, 19, 9);
            MapBuilderY(3, 19, 11);
            MapBuilderY(2, 9, 13);
            MapBuilderY(4, 12, 15);
            MapBuilderY(12, 16, 13);
            MapBuilderY(16, 18, 15);
            MapBuilderX(12, 15, 19);
            Place(6, 7, _wallSymbol, BuildType.DefaultWall);
            Place(5, 9, _wallSymbol, BuildType.DefaultWall);
            Place(6, 11, _wallSymbol, BuildType.DefaultWall);
            Place(5, 13, _wallSymbol, BuildType.DefaultWall);
            Place(5, 14, _wallSymbol, BuildType.DefaultWall);
            Place(6, 16, _wallSymbol, BuildType.DefaultWall);
            Place(6, 17, _wallSymbol, BuildType.DefaultWall);
            Place(8, 19, _wallSymbol, BuildType.DefaultWall);
            Place(12, 9, _wallSymbol, BuildType.DefaultWall);
            Place(14, 12, _wallSymbol, BuildType.DefaultWall);
            Place(14, 16, _wallSymbol, BuildType.DefaultWall);
            #endregion

            Place(8, 18, _winElementSymbol, BuildType.WinWall);
        }
        public void RenderMap()
        {
            foreach (var element in _map)
            {
                if (element is WallElement) { element.Draw(); }
            }
        }
        void Place(int x, int y, char drawSymbol, BuildType buildType)
        {
            switch (buildType)
            {
                case BuildType.DefaultWall:
                    if (!_map.Contains(new WallElement(drawSymbol, x, y)))
                    {
                        WallElement wallElement = new WallElement(drawSymbol, x, y);
                        _map.Add(wallElement);
                    }
                    break;
                case BuildType.WinWall:
                    if (!_map.Contains(new WinElement(drawSymbol, x, y)))
                    {
                        WinElement winElement = new WinElement(drawSymbol, x, y);
                        _map.Add(winElement);
                    }
                    break;
            }
        }
        void MapBuilderX(int minX, int maxX, int y)
        {
            for (int x = minX; x <= maxX; x++)
            {
                Place(x, y, _wallSymbol, BuildType.DefaultWall);
            }
        }
        void MapBuilderY(int minY, int maxY, int x)
        {
            for (int y = minY; y <= maxY; y++)
            {
                Place(x, y, _wallSymbol, BuildType.DefaultWall);
            }
        }
    }
}