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

        public static void DrawLunarBrick(Graphics g, int x, int y, int sqr)
        {
            // Base color of the brick
            SolidBrush grayBlueBrush = new SolidBrush(Color.FromArgb(255, 100, 100, 140)); // A=255, R=100, G=100, B=140
            
            // Highlights and shadows 
            Brush highlightColor = Brushes.LightGray;
            Brush shadowColor = Brushes.DarkGray;

            // Drawing the base of the brick
            g.FillEllipse(grayBlueBrush, x * sqr, y * sqr, sqr, sqr);
            
            // Highlights to simulate the lunar surface texture
            g.FillEllipse(highlightColor, (x * sqr) + (sqr / 4), (y * sqr) + (sqr / 4), sqr / 6, sqr / 6);
            g.FillEllipse(shadowColor, (x * sqr) + (sqr / 2), (y * sqr) + (sqr / 3), sqr / 5, sqr / 5);
            
            // Drawing craters with varying sizes and shades to simulate the lunar surface
            g.FillEllipse(shadowColor, (x * sqr) + (sqr / 4), (y * sqr) + (sqr / 2), sqr / 8, sqr / 8);
            g.FillEllipse(highlightColor, (x * sqr) + (3 * sqr / 4), (y * sqr) + (sqr / 4), sqr / 10, sqr / 10);

            // Adding more detailed shadows and highlights to enhance the lunar effect
            g.FillEllipse(shadowColor, (x * sqr) + (sqr / 5), (y * sqr) + (3 * sqr / 4), sqr / 7, sqr / 7);
            g.FillEllipse(highlightColor, (x * sqr) + (sqr / 6), (y * sqr) + (sqr / 6), sqr / 8, sqr / 8);
        }


    }
}
