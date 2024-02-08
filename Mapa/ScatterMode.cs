using System;
using System.Reflection;
using PacMan;

namespace Mapa
{
    public class ScatterMode : IMoveBehaviour
    {
        public int scatterCounter = 0;
        public int scatterDuration;
        public int scatterModeHappenings = 0;
        private char target;

        public void Move(Ghost ghost, Map map)
        {
            // set duration to 7 sconds if Scatter mode hasn't happened more than once, otherwise set it to 5 seconds
            scatterDuration = scatterModeHappenings < 2 ? 520 : 400; 

            if (scatterCounter < scatterDuration)
            {
                RetreatToCorner(ghost, map);
                scatterCounter++;
            }
            else
            {
                scatterCounter = 0;
                ghost.CurrentMode = Ghost.GhostMode.Chase;
            }
        }

        public void RetreatToCorner(Ghost ghost, Map map)
        {
            switch (ghost.Identifier)
            {
                case "blinky":
                    target = 'R';
                    break;
                case "pinky":
                    target = 'K';
                    break;
                case "inky":
                    target = 'I';
                    break;
                case "clyde":
                    target = 'O';
                    break;
            }

            (int targetX, int targetY) = map.SearchTarget(target);
            
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