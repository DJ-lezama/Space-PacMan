using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan
{
    internal class Pacman
    {
        
        public int sqr = 20;
        public int X { get; set; }
        public int Y { get; set; }

        public Pacman(int startX, int startY, int squareSize)
        {
            this.X = startX;
            this.Y = startY;
            this.sqr = squareSize;
        }

        public void PacmanMove(int deltaX, int deltaY, Map map)
        {
            int newX = X + deltaX;
            int newY = Y + deltaY;

            // Check if the new position is passable before moving.
            if (map.IsPassable(newX, newY))
            {
                X = newX;
                Y = newY;
            }

            // Check and eat the pill or power pellet at the new position.
            map.EatPillOrPellet(newX, newY);
        }

        public void Anim(Graphics g, int cntT)
        {
            //g.Clear(Color.Transparent);

            int drawX = X * sqr;
            int drawY = Y * sqr;


            switch (cntT % 6)
            {
                case 0:
                    g.FillEllipse(Brushes.Yellow, drawX, drawY, sqr, sqr);
                    break;
                case 1:
                    g.FillEllipse(Brushes.Yellow, drawX, drawY, sqr, sqr);
                    break;
                case 2:
                    g.FillPie(Brushes.Yellow, drawX, drawY, sqr, sqr, 30, 300);
                    break;
                case 3:
                    g.FillPie(Brushes.Yellow, drawX, drawY, sqr, sqr, 45, 240);
                    break;
                case 4:
                    g.FillPie(Brushes.Yellow, drawX, drawY, sqr, sqr, 30, 300);
                    break;
                case 5:
                    g.FillEllipse(Brushes.Yellow, drawX, drawY, sqr, sqr);
                    break;
            }

            if (cntT % 6 != 0)
            {
                g.FillEllipse(Brushes.Black, drawX + sqr / 5, drawY + sqr / 5, sqr / 5, sqr / 5);
            }
        }

    }
}
