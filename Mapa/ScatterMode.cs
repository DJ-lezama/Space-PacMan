using System;
using System.Collections.Generic;
using System.Reflection;
using PacMan;

namespace Mapa
{
    public class ScatterMode : IMoveBehaviour
    {
        public int scatterCounter;
        public int scatterDuration;
        public int scatterModeHappenings = 0;
        private char target;

        public void Move(Ghost ghost, Map map)
        {
            // set duration to 7 sconds if Scatter mode hasn't happened more than once, otherwise set it to 5 seconds
            scatterDuration = scatterModeHappenings < 2 ? 480 : 400;

            (int targetX, int targetY) = GetTarget(ghost, map);
            
            if (scatterCounter < scatterDuration)
            {
                RetreatToCorner(ghost, map, targetX, targetY);
                scatterCounter++;
            }
            //Change from scatter mode if the counter is grater or equal than duration or the ghost has reached its target
            else if (scatterCounter >= scatterDuration || (ghost.x == targetX && ghost.y == targetY))
            {
                scatterCounter = 0;
                ghost.CurrentMode = Ghost.GhostMode.Chase;
            }
        }

        public (int, int) GetTarget(Ghost ghost, Map map)
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
            return (targetX, targetY);
        }

        public void RetreatToCorner(Ghost ghost, Map map, int targetX, int targetY)
        {
            
            // Calculate the current deltaX and deltaY between the ghost and Pacman
            int currentDeltaX = Math.Abs(targetX - (int)ghost.x);
            int currentDeltaY = Math.Abs(targetY - (int)ghost.y);

            // Possible moves based on the ghost's current direction
            List<(int x, int y)> possibleMoves = new List<(int x, int y)>();

            // Add all possible moves
            if (map.IsPassable((int)ghost.x - 1, (int)ghost.y)) possibleMoves.Add(((int)ghost.x - 1, (int)ghost.y)); // Left
            if (map.IsPassable((int)ghost.x + 1, (int)ghost.y)) possibleMoves.Add(((int)ghost.x + 1, (int)ghost.y)); // Right
            if (map.IsPassable((int)ghost.x, (int)ghost.y - 1)) possibleMoves.Add(((int)ghost.x, (int)ghost.y - 1)); // Up
            if (map.IsPassable((int)ghost.x, (int)ghost.y + 1)) possibleMoves.Add(((int)ghost.x, (int)ghost.y + 1)); // Down

            // Initialize variables to track the best move
            (int x, int y) bestMove = ((int)ghost.x, (int)ghost.y);
            int bestDelta = currentDeltaX + currentDeltaY; // Combined delta as a simple heuristic

            // Evaluate each possible move
            foreach (var move in possibleMoves)
            {
                int newDeltaX = Math.Abs(targetX - move.x);
                int newDeltaY = Math.Abs(targetY - move.y);
                int newCombinedDelta = newDeltaX + newDeltaY;

                // Choose the move that decreases the delta (gets closer to Pacman)
                if (newCombinedDelta <= bestDelta)
                {
                    bestDelta = newCombinedDelta;
                    bestMove = move;
                }
            }

            // Move the ghost to the position that brings it closer (or keeps it the same distance) to Pacman
            ghost.x = bestMove.x;
            ghost.y = bestMove.y;
        }
    }
}