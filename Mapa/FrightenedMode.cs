using System;
using System.Collections.Generic;
using PacMan;

namespace Mapa
{
    public class FrightenedMode : IMoveBehaviour
    {
        Random rand = new Random();

        public void Move(Ghost ghost, Map map, Canvas canvas)
        {
            // Define potential directions a ghost can move
            var potentialDirections = new List<Ghost.Direction> { Ghost.Direction.Up, Ghost.Direction.Down, Ghost.Direction.Left, Ghost.Direction.Right };

            // Remove the current direction to avoid moving back
            potentialDirections.Remove(ghost.direction);

            // Filter valid directions where the ghost can actually move
            var validDirections = new List<Ghost.Direction>();
            foreach (var direction in potentialDirections)
            {
                if (IsValidDirection(ghost, direction, map))
                {
                    validDirections.Add(direction);
                }
            }

            // Choose a random valid direction
            if (validDirections.Count > 0)
            {
                var newDirection = validDirections[rand.Next(validDirections.Count)];
                MoveGhostInDirection(ghost, newDirection);
                ghost.UpdateDirection((int)ghost.x, (int)ghost.y); // Assuming UpdateDirection method now properly updates based on last move
            }
        }

        private bool IsValidDirection(Ghost ghost, Ghost.Direction direction, Map map)
        {
            // Check next position based on direction
            int nextX = (int)ghost.x, nextY = (int)ghost.y;
            switch (direction)
            {
                case Ghost.Direction.Up: nextY -= 1; break;
                case Ghost.Direction.Down: nextY += 1; break;
                case Ghost.Direction.Left: nextX -= 1; break;
                case Ghost.Direction.Right: nextX += 1; break;
            }

            // Check if next position is within bounds and not a wall
            return map.IsPassable(nextX, nextY);
        }

        private void MoveGhostInDirection(Ghost ghost, Ghost.Direction direction)
        {
            // Update ghost position based on direction
            switch (direction)
            {
                case Ghost.Direction.Up: ghost.y -= 1; break;
                case Ghost.Direction.Down: ghost.y += 1; break;
                case Ghost.Direction.Left: ghost.x -= 1; break;
                case Ghost.Direction.Right: ghost.x += 1; break;
            }
        }
    }
}