using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PacMan;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Mapa
{
    public class BlinkyChaseMode : IMoveBehaviour
    {
        public Ghost g;
        public Map m;
        public PointF p, gh;

        public void Move(Ghost ghost, Map map)
        {
            g = ghost;
            m = map;

            // Access Pacman's position through the map
            p = new PointF (map.pacman.X, map.pacman.Y);

            gh = new PointF(g.x, g.y);

            switch (g.direction)
            {
                case Ghost.Direction.Up:
                    g.direction = Ghost.Direction.Down;
                    break;
                case Ghost.Direction.Down:
                    g.direction = Ghost.Direction.Up;
                    break;
                case Ghost.Direction.Right:
                    g.direction = Ghost.Direction.Left;
                    break;
                case Ghost.Direction.Left:
                    g.direction = Ghost.Direction.Right;
                    break;
            }

            var path = AStarSearch(map, gh, p);

            // Move to the next step in the path if it exists
            if (path.Any())
            {
                gh = path.First();
            }
        }

        private AStarSearch(Map map, PointF start, PointF goal)
        {
            // This function should implement the A* algorithm to find the shortest path
            // from start to goal. For simplicity, this example will just return an empty list.
            // You'll need to fill in the actual A* logic here.
            return;
        }
    }
}