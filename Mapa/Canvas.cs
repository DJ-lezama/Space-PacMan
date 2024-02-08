﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace PacMan
{
    public class Canvas
    {
        public Map map = new Map();
        public Graphics g;
        public Pacman pacman;
        public Ghost redGhost;
        public Ghost pinkGhost;
        public Ghost blueGhost;
        public Ghost orangeGhost;
        public List<Ghost> ghosts = new List<Ghost>();
        public int sqr = 20;
        public Canvas(Bitmap bmp)
        {
            g = Graphics.FromImage(bmp);
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
            InitializePacman();
            InitializeGhosts();
            map.SetCanvas(this); 
        }

        public void InitializePacman()
        {
            int x = FindPacmanStartPosition().Item1;
            int y = FindPacmanStartPosition().Item2;
            pacman = new Pacman(x, y, sqr);
            map.SetPacman(pacman);
            map.SetCanvas(this);
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
                            redGhost = new Ghost(x, y, "blinky", Ghost.Direction.Right);
                            ghosts.Add(redGhost);
                            break;
                        case 'B':
                            pinkGhost = new Ghost(x, y, "pinky", Ghost.Direction.Right);
                            ghosts.Add(pinkGhost);
                            break;
                        case 'C':
                            blueGhost = new Ghost(x, y, "inky", Ghost.Direction.Left);
                            ghosts.Add(blueGhost);
                            break;
                        case 'D':
                            orangeGhost = new Ghost(x, y, "clyde", Ghost.Direction.Left);
                            ghosts.Add(orangeGhost);
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
                            Brick.DrawLunarBrick(g, x, y, sqr);
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

            redGhost.AnimGhost(g, counter_timer, pacman.poweredUp ? Brushes.DarkBlue : Brushes.Red, map);
            pinkGhost.AnimGhost(g, counter_timer, pacman.poweredUp ? Brushes.DarkBlue : Brushes.LightPink, map);
            blueGhost.AnimGhost(g, counter_timer, pacman.poweredUp ? Brushes.DarkBlue : Brushes.LightSkyBlue, map);
            orangeGhost.AnimGhost(g, counter_timer, pacman.poweredUp ? Brushes.DarkBlue : Brushes.Orange, map);
        } 
    }
}
