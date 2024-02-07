using System;
using PacMan;

namespace Mapa
{
    public class BlinkyChaseMode : IMoveBehaviour
    {
        public void Move(Ghost ghost, Map map)
        {
            // Access Pacman's position through the map
            int targetX = map.pacman.X;
            int targetY = map.pacman.Y;

            // Potential new positions
            int newX = (int)ghost.x;
            int newY = (int)ghost.y;

            // Calculate the difference in positions
            int diffX = targetX - newX;
            int diffY = targetY - newY;

            // Decide on move based on which difference is greater and check for walls
            if (Math.Abs(diffX) > Math.Abs(diffY))
            {
                // Attempt to move in X direction if no wall is present
                if (map.IsPassable(newX + Math.Sign(diffX), newY))
                {
                    newX += Math.Sign(diffX);
                }
            }
            else
            {
                // Attempt to move in Y direction if no wall is present
                if (map.IsPassable(newX, newY + Math.Sign(diffY)))
                {
                    newY += Math.Sign(diffY);
                }
            }

            // Update ghost's position if the move is valid
            ghost.x = newX;
            ghost.y = newY;
        }
    }
}