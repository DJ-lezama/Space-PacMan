using Mapa;
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
        public float initialX, initialY; // Store initial positions
        private int sqr = 20;
        public enum GhostMode
        {
            Scatter,
            Chase,
            Frightened
        }


        public IMoveBehaviour MoveBehaviour { get; set; }
        public GhostMode CurrentMode { get; set; }
        public string Identifier { get; set; }

        public Ghost(float x, float y, String identifier)
        {
            isAlive = true;
            this.x = x;
            this.y = y;

            this.initialX = x;
            this.initialY = y;

            this.CurrentMode = GhostMode.Chase;
            this.Identifier = identifier;
        }

        public void PerformMove(Map map)
        {
            MoveBehaviour.Move(this, map);
        }
        
        public void GhostMove(char[,] level)
        {
            if (!isAlive)
            {
                // Skip movement if the ghost is not alive
                return;
            }

            // Array of possible movement directions
            (int dx, int dy)[] directions = new (int, int)[] { (0, -1), (0, 1), (-1, 0), (1, 0) };
            int newIndex = rand.Next(directions.Length); // Randomly select a direction
            int newX = (int)x + directions[newIndex].Item1;
            int newY = (int)y + directions[newIndex].Item2;

            // Check if new position is within bounds and not a wall ('0' represents a wall in the level array)
            if (newX >= 0 && newX < level.GetLength(1) && newY >= 0 && newY < level.GetLength(0) && level[newY, newX] != '0')
            {
                x = newX;
                y = newY;
            }
            // If the selected position is not valid, the ghost does not move. This is a simple logic to keep the ghost moving.
        }


        public void AnimGhost(Graphics g, int cntT, Brush ghostColor)
        {
            
            if (isAlive)
            {
                //g.FillEllipse(new SolidBrush(Color.FromArgb(65, 250, 250, 50)), (x * sqr), (y * sqr), sqr, sqr);
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
                // Eyes
                if (((cntT + rand.Next(1, 17)) % 11) == 0)
                {
                    //Close eyes
                    g.FillEllipse(Brushes.Linen, (x * sqr) + 10, (y * sqr) + 2, sqr - 12, sqr - 12);
                    g.FillEllipse(Brushes.Black, (x * sqr) + 14, (y * sqr) + 8, sqr - 18, sqr - 22);

                    g.FillEllipse(Brushes.Linen, (x * sqr) + 2, (y * sqr) + 2, sqr - 12, sqr - 12);
                    g.FillEllipse(Brushes.Black, (x * sqr) + 6, (y * sqr) + 8, sqr - 18, sqr - 22);
                }
                else
                {
                    //Init pos
                    g.FillEllipse(Brushes.Linen, (x * sqr) + 2, (y * sqr) + 2, sqr - 12, sqr - 12);
                    g.FillEllipse(Brushes.Linen, (x * sqr) + 10, (y * sqr) + 2, sqr - 12, sqr - 12);
                }

            }
            else
            {
               
                // Calculate the step towards the initial position
                float stepX = (initialX - x) * 0.05f; // Adjust the multiplier for speed
                float stepY = (initialY - y) * 0.05f;

                x += stepX;
                y += stepY;

                // Drawing eyes for the respawning animation
                g.FillEllipse(Brushes.White, (x * sqr) + sqr / 4, (y * sqr) + sqr / 4, sqr / 4, sqr / 4); // Left eye
                g.FillEllipse(Brushes.Black, (x * sqr) + sqr / 4 + sqr / 8, (y * sqr) + sqr / 4 + sqr / 8, sqr / 8, sqr / 8); // Left pupil

                g.FillEllipse(Brushes.White, (x * sqr) + 3 * sqr / 4 - sqr / 4, (y * sqr) + sqr / 4, sqr / 4, sqr / 4); // Right eye
                g.FillEllipse(Brushes.Black, (x * sqr) + 3 * sqr / 4 - sqr / 8, (y * sqr) + sqr / 4 + sqr / 8, sqr / 8, sqr / 8); // Right pupil

                // Check if the ghost has reached its initial position to make it alive again
                if (Math.Abs(x - initialX) < 0.1 && Math.Abs(y - initialY) < 0.1)
                {
                    isAlive = true; // Respawn the ghost once it reaches its initial position
                }
            }
        }

        public void HandleBeingEaten()
        {
            this.isAlive = false;
        }


    }
}
