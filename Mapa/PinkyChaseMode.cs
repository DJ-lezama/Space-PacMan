using System;
using System.Collections.Generic;
using PacMan;

namespace Mapa
{
    public class PinkyChaseMode : IMoveBehaviour
    {
        public void Move(Ghost ghost, Map map)
        {
            //Set target 
            int targetX = map.pacman.X;
            int targetY = map.pacman.Y;
            
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