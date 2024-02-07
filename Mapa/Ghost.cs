using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public class Ghost
    {
        public Boolean isAlive;
        Random rand = new Random();
        public float x, y;
        private int sqr = 20;

       public Ghost(float x, float y)
        {
            isAlive = true;
            this.x = x;
            this.y = y;
        }

        public void AnimGhost(Graphics g, int cntT, Brush ghostColor)
        {
            
            if (isAlive)
            {
                g.FillEllipse(new SolidBrush(Color.FromArgb(65, 250, 250, 50)), (x * sqr), (y * sqr), sqr, sqr);
                g.FillEllipse(ghostColor, (x * sqr) + 2, (y * sqr) - 2, sqr - 4, sqr - 6);
                g.FillRectangle(ghostColor, (x * sqr) + 2, (y * sqr) + 2, sqr - 4, sqr - 8);

                if (((cntT + rand.Next(1, 7)) % 3) == 0){
                    g.FillEllipse(ghostColor, (x * sqr), (y * sqr) + (3 * sqr) / 6, sqr / 5, sqr / 2);
                    g.FillEllipse(ghostColor, (x * sqr) + (2 * sqr) / 7, (y * sqr) + ( 3 * sqr) / 6, sqr / 5, sqr / 2);
                    g.FillEllipse(ghostColor, (x * sqr) + (4 * sqr) / 7, (y * sqr) + (3 * sqr) / 6, sqr / 5, sqr / 2);
                    g.FillEllipse(ghostColor, (x * sqr) + (6 * sqr) / 7, (y * sqr) + (3 * sqr) / 6, sqr / 5, sqr / 2);
                } else
                {
                    g.FillEllipse(ghostColor, (x * sqr) + (sqr) / 8, (y * sqr) + (3 * sqr) / 6, sqr / 5, sqr / 2);
                    g.FillEllipse(ghostColor, (x * sqr) + (2 + sqr) / 8, (y * sqr) + (3 * sqr) / 6, sqr / 5, sqr / 2);
                    g.FillEllipse(ghostColor, (x * sqr) + (4 + sqr) / 8, (y * sqr) + (3 * sqr) / 6, sqr / 5, sqr / 2);
                    g.FillEllipse(ghostColor, (x * sqr) + (6 + sqr) / 8, (y * sqr) + (3 * sqr) / 6, sqr / 5, sqr / 2);

                }
            }

            // Eyes
            if (((cntT + rand.Next(1, 17)) % 11) == 0)
            {
                //Close eyes
                g.FillEllipse(Brushes.Linen, (x * sqr) + 10, (y * sqr) + 2, sqr - 12, sqr - 12);
                g.FillEllipse(Brushes.Black, (x * sqr) + 14, (y * sqr) + 8, sqr - 18, sqr - 22);

                g.FillEllipse(Brushes.Linen, (x * sqr) + 2, (y * sqr) + 2, sqr - 12, sqr - 12);
                g.FillEllipse(Brushes.Black, (x * sqr) + 6, (y * sqr) + 8, sqr - 18, sqr - 22);
            } else
            {
                //Init pos
                g.FillEllipse(Brushes.Linen, (x * sqr) + 2, (y * sqr) + 2, sqr - 12, sqr - 12);
                g.FillEllipse(Brushes.Linen, (x * sqr) + 10, (y * sqr) + 2, sqr - 12, sqr - 12);
            }
        }

        public void HandleBeingEaten()
        {
            isAlive = false;

        }


    }
}
