using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Tile(int x, int y)
        {
            X = x;
            Y = y;

        }

        public static Tile GetTileAtDestination(Position newPosition)
        {
            foreach(Tile tile in World.Tiles)
            {
                if (tile.X == newPosition.XCoord && tile.Y == newPosition.YCoord)
                {
                    return tile;
                }
            }
            return null;
        }
    }
}
