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
        Search s;

        public void Move(Ghost ghost, Map map)
        {
            g = ghost;

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

            s = new Search(map);
        }
        */
    }
}