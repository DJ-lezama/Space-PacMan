using System;
using System.Collections.Generic;
using PacMan;

namespace Mapa
{
    public class ScatterMode : IMoveBehaviour
    {
        private static int _scatterDuration;
        public int scatterModeHappenings = 0;
        private char _target;

        public void Move(Ghost ghost, Map map, Canvas c)
        {
            // set duration to 7 seconds if Scatter mode hasn't happened more than once, otherwise set it to 5 seconds
            _scatterDuration = scatterModeHappenings < 2 ? 160 : 240;

            var (targetX, targetY) = GetTarget(ghost, map);
            
            if (ghost.scatterCounter < _scatterDuration && (Math.Abs((int)ghost.x - targetX) >= 0.5 && Math.Abs((int)ghost.y - targetY) >= 0.5))
            {
                RetreatToCorner2(ghost, map, targetX, targetY);
                ghost.scatterCounter++;
            }
            
            //Change from scatter mode if the counter is grater or equal than duration or the ghost has reached its target
            else //if (ghost.scatterCounter >= _scatterDuration || (Math.Abs((int)ghost.x - targetX) <= 0.5 && Math.Abs((int)ghost.y - targetY) <= 0.5))
            {
                ghost.scatterCounter = 0;
                ghost.CurrentMode = Ghost.GhostMode.Chase;
                switch (ghost.Identifier)
                {
                    case "blinky":
                        ghost.MoveBehaviour = new BlinkyChaseMode();
                        break;
                    case "pinky":
                        ghost.MoveBehaviour = new PinkyChaseMode();
                        break;
                    case "inky":
                        ghost.MoveBehaviour = new InkyChaseMode();
                        break;
                    case "clyde":
                        ghost.MoveBehaviour = new ClydeChaseMode();
                        break;
                }
            }
        }

        private (int, int) GetTarget(Ghost ghost, Map map)
        {
            switch (ghost.Identifier)
            {
                case "blinky":
                    _target = 'R';
                    break;
                case "pinky":
                    _target = 'K';
                    break;
                case "inky":
                    _target = 'I';
                    break;
                case "clyde":
                    _target = 'O';
                    break;
            }
            (int targetX, int targetY) = map.SearchTarget(_target);
            return (targetX, targetY);
        }

        private void RetreatToCorner2(Ghost ghost, Map map, int targetX, int targetY)
        {
            Search search = new Search(map, ghost);
            Node startNode = search.grid[(int)ghost.x, (int)ghost.y];
            Node targetNode = search.grid[targetX, targetY];
            
            List<Node> path = search.FindPath(startNode, targetNode);

            if (path != null && path.Count > 0)
            {
                Node nextNode = path.Count == 1 ? path[0] : path[1];
                ghost.x = nextNode.X;
                ghost.y = nextNode.Y;
            }
        }
    }
}