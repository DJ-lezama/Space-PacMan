using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    internal class Pill
    {
        static Random rand;
        public Pill()
        {

        }

        public static void DrawPill(Graphics g, int x, int y, int sqr, int cntT)
        {
            if (rand == null) 
            { 
                rand = new Random();
            }

            if (((cntT * rand.Next(1, 5)) % 5) == 0)
            {
                g.FillEllipse(Brushes.Goldenrod, (x * sqr) + 8, (y * sqr) + 8, sqr - 16, sqr - 16);
            } else
            {
                g.FillEllipse(Brushes.Gold, (x * sqr) + 8, (y * sqr) + 8, sqr - 16, sqr - 16);
                g.FillEllipse(Brushes.Goldenrod, (x * sqr) + 10, (y * sqr) + 10, sqr - 20, sqr - 20);
            }
        }

        public static void DrawPowerPellet(Graphics g, int x, int y, int sqr, int cntT)
        {
            if (rand == null)
            {
                rand = new Random();
            }

            if (((cntT + rand.Next(1,5)) % 5) == 0)
            {
                g.FillEllipse(new SolidBrush(Color.FromArgb(35, 200, 180)), (x * sqr), (y * sqr), sqr, sqr);
                g.FillEllipse(Brushes.Yellow, (x * sqr) + 3, (y * sqr) + 3, sqr - 6, sqr - 6);
                g.FillEllipse(Brushes.Linen, (x * sqr) + 5, (y * sqr) + 5, sqr - 10, sqr - 10);
            } else
            {
                g.FillEllipse(new SolidBrush(Color.FromArgb(100, 200, 200, 180)), (x * sqr), (y * sqr), sqr, sqr);
                g.FillEllipse(Brushes.Orange, (x * sqr) + 2, (y * sqr) + 2, sqr - 4, sqr - 4);
                g.FillEllipse(new SolidBrush(Color.FromArgb(100, 100, 150, 180)), (x * sqr) + 5, (y * sqr) + 5, sqr - 10, sqr - 10);   
            }
        }
    }
}
