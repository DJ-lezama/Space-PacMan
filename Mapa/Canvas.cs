using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    internal class Canvas
    {
        public Map map = new Map();
        public Graphics g;
        public Pacman pacman;
        public Ghost redGhost;
        public Ghost pinkGhost;
        public Ghost blueGhost;
        public Ghost orangeGhost;
        public int sqr = 20;
        public Canvas(Bitmap bmp)
        {
            g = Graphics.FromImage(bmp);
            InitializePacman();
            InitializeGhosts();
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
                        map.SetPacman(pacman);
                        return; 
                    }
                }
            }
        }

        private void InitializeGhosts()
        {
            for (int y = 0; y < map.level.GetLength(0); y++)
            {
                for (int x = 0; x < map.level.GetLength(1); x++)
                {
                    switch (map.level[y, x])
                    {
                        case 'A':
                            redGhost = new Ghost(x, y);
                            break;
                        case 'B':
                            pinkGhost = new Ghost(x, y);
                            break;
                        case 'C':
                            blueGhost = new Ghost(x, y);
                            break;
                        case 'D':
                            orangeGhost = new Ghost(x, y);
                            break;
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

            
            redGhost.AnimGhost(g, counter_timer, pacman.poweredUp ? Brushes.DarkBlue : Brushes.Red);
            pinkGhost.AnimGhost(g, counter_timer, pacman.poweredUp ? Brushes.DarkBlue : Brushes.LightPink);
            blueGhost.AnimGhost(g, counter_timer, pacman.poweredUp ? Brushes.DarkBlue : Brushes.LightSkyBlue);
            orangeGhost.AnimGhost(g, counter_timer, pacman.poweredUp ? Brushes.DarkBlue : Brushes.Orange);
            

        }

       
    }
}
