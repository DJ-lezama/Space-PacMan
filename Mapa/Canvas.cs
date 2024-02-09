using System;
using System.Collections.Generic;
using System.Drawing;

namespace PacMan
{
    public class Canvas
    {
        public Map map = new Map();
        private Graphics _g;
        public Pacman pacman;
        private Ghost _redGhost;
        private Ghost _pinkGhost;
        private Ghost _blueGhost;
        private Ghost _orangeGhost;
        public List<Ghost> ghosts = new List<Ghost>();
        public int sqr = 20;
        public Canvas(Bitmap bmp)
        {
            _g = Graphics.FromImage(bmp);
            InitializePacman();
            InitializeGhosts();
        }

        private (int, int) FindPacmanStartPosition() // Find 'P' in the map to set Pacman's starting position
        {
            for (int y = 0; y < map.level.GetLength(0); y++)
            {
                for (int x = 0; x < map.level.GetLength(1); x++)
                {
                    if (map.level[y, x] == 'P')
                    {
                        return (x, y);
                    }
                }
            }
            return (-1, -1); // Default value indicating position not found
        }
        public void SetMap(Map newMap)
        {
            this.map = newMap;
            map.SetCanvas(this); 
            InitializePacman();
            InitializeGhosts();
        }

        public void InitializePacman()
        {
            map.SetCanvas(this);
            int x = FindPacmanStartPosition().Item1;
            int y = FindPacmanStartPosition().Item2;
            pacman = new Pacman(x, y, sqr);
            map.SetPacman(pacman);
            return;
        }

        public void RespawnPacman()
        {
            if (pacman != null && FindPacmanStartPosition() != (-1, -1))
            {
                pacman.X = FindPacmanStartPosition().Item1;
                pacman.Y = FindPacmanStartPosition().Item2;
                pacman.isAlive = true;

            }
        }
        public void InitializeGhosts()
        {
            for (int y = 0; y < map.level.GetLength(0); y++)
            {
                for (int x = 0; x < map.level.GetLength(1); x++)
                {
                    switch (map.level[y, x])
                    {
                        case 'A':
                            _redGhost = new Ghost(x, y, "blinky", Ghost.Direction.Right);
                            _redGhost.CurrentMode = Ghost.GhostMode.Chase;
                            ghosts.Add(_redGhost);
                            break;
                        case 'B':
                            _pinkGhost = new Ghost(x, y, "pinky", Ghost.Direction.Right);
                            _pinkGhost.CurrentMode = Ghost.GhostMode.Chase;
                            ghosts.Add(_pinkGhost);
                            break;
                        case 'C':
                            _blueGhost = new Ghost(x, y, "inky", Ghost.Direction.Left);
                            _blueGhost.CurrentMode = Ghost.GhostMode.Chase;
                            ghosts.Add(_blueGhost);
                            break;
                        case 'D':
                            _orangeGhost = new Ghost(x, y, "clyde", Ghost.Direction.Left);
                            _orangeGhost.CurrentMode = Ghost.GhostMode.Chase;
                            ghosts.Add(_orangeGhost);
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
                    _g.FillRectangle(Brushes.Black, x * sqr, y * sqr, sqr, sqr);
                    switch (map.level[y, x])
                    {
                        case '0':
                            Brick.DrawLunarBrick(_g, x, y, sqr);
                            break;
                        case '1':
                            Pill.DrawPill(_g, x, y, sqr, counter_timer);
                            break;
                        case '2':
                            Pill.DrawPowerPellet(_g, x, y, sqr, counter_timer);
                            break;                        
                    }
                }
            }

            if (pacman != null) 
            {
                pacman.Anim(_g, counter_timer);
            }

            _redGhost.AnimGhost(_g, counter_timer, pacman.poweredUp ? Brushes.DarkBlue : Brushes.Crimson, map);
            _pinkGhost.AnimGhost(_g, counter_timer, pacman.poweredUp ? Brushes.DarkBlue : Brushes.Thistle, map);
            _blueGhost.AnimGhost(_g, counter_timer, pacman.poweredUp ? Brushes.DarkBlue : Brushes.DeepSkyBlue, map);
            _orangeGhost.AnimGhost(_g, counter_timer, pacman.poweredUp ? Brushes.DarkBlue : Brushes.Coral, map);
        } 
    }
}
