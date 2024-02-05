using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapa
{
    internal class Canvas
    {
        public Map map = new Map();
        public Graphics g;
        public Pacman pacman;
        public int sqr = 20;
        public Canvas(Bitmap bmp)
        {
            g = Graphics.FromImage(bmp);
            InitializePacman();
        }

        private void InitializePacman()
        {
            // Find 'P' in the map to set Pacman's starting position
            for (int y = 0; y < map.level.GetLength(0); y++)
            {
                for (int x = 0; x < map.level.GetLength(1); x++)
                {
                    if (map.level[y, x] == 'P')
                    {
                        pacman = new Pacman(x, y, sqr);
                        return; 
                    }
                }
            }
        }

        public void DrawMap(int counter_timer)
        {
            for (int y = 0; y < map.level.GetLength(0); y++) 
            {
                for (int x = 0; x < map.level.GetLength(1); x++)
                {
                    g.FillRectangle(Brushes.Black, x * sqr, y * sqr, sqr, sqr);
                    switch (map.level[y, x])
                    {
                        case '0':
                            Brick.DrawBrick(g, x, y, sqr);
                            break;
                        case '1':
                            Pill.DrawPill(g, x, y, sqr, counter_timer);
                            break;
                        case '2':
                            Pill.DrawPowerPellet(g, x, y, sqr, counter_timer);
                            break;                        
                    }
                }
            }

            if (pacman != null) 
            {
                pacman.Anim(g, counter_timer);
            }
        }

       
    }
}
