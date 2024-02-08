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

            // Define el centro y el radio de la estrella
            float centerX = x * sqr + sqr / 2;
            float centerY = y * sqr + sqr / 2;
            float radius = sqr / 3f;
            float innerRadius = radius / 2.5f;

            // Crea un path para dibujar la estrella
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            // Define los puntos de la estrella
            double angle = Math.PI / 5; // Ángulo entre los puntos de la estrella

            for (int i = 0; i < 10; i++)
            {
                float r = (i % 2 == 0) ? radius : innerRadius;
                float pointX = centerX + (float)(r * Math.Sin(i * angle));
                float pointY = centerY - (float)(r * Math.Cos(i * angle));
                if (i == 0)
                {
                    path.StartFigure();
                    path.AddLine(pointX, pointY, pointX, pointY);
                }
                else
                {
                    path.AddLine(path.GetLastPoint(), new PointF(pointX, pointY));
                }
            }
            path.CloseFigure();

            // Decide el color basado en el contador de tiempo para animar la estrella
            if (((cntT + rand.Next(1, 5)) % 5) == 0)
            {
                g.FillPath(new SolidBrush(Color.FromArgb(35, 200, 180)), path);
                g.FillPath(Brushes.Yellow, path);
            }
            else
            {
                g.FillPath(new SolidBrush(Color.FromArgb(100, 200, 200, 180)), path);
                g.FillPath(Brushes.Orange, path);
            }
        }

    }
}
