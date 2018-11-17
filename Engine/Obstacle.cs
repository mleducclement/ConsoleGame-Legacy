using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Obstacle : Tile
    {
        public Obstacle(int x, int y) : base(x, y)
        {

        }

        //Check if the destination tile when the player moves is a wall or not
        public static bool CheckIfObstacle(Position newPosition)
        {
            foreach (Tile tile in World.Tiles)
            {
                if (tile.X == newPosition.XCoord && tile.Y == newPosition.YCoord)
                {
                    if (tile is Obstacle)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
