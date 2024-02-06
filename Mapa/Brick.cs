using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    internal class Brick
    {
        public Brick() { }

        public static void DrawBrick(Graphics g, int x, int y, int sqr)
        {
            g.FillRectangle(Brushes.DarkBlue, x * sqr, y * sqr, sqr, sqr);
            g.FillRectangle(Brushes.DarkCyan, (x * sqr) + 4, (y * sqr) + 4, sqr - 8, sqr - 8);

            g.DrawLine(Pens.Black, (x * sqr), (y * sqr), (x * sqr) + sqr, (y * sqr) + sqr - 1);

            g.DrawLine(Pens.DimGray, (x * sqr), (y * sqr), (x * sqr) + sqr / 2, (y * sqr) + sqr / 2);
            g.DrawLine(Pens.Black, (x * sqr), (y * sqr) + sqr, (x * sqr) + sqr, (y * sqr));

        }
    }
}
