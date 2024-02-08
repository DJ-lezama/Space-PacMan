using Mapa;
using System;
using System.Drawing;

namespace PacMan
{
    public class Ghost
    {
        public Boolean isAlive;
        Random rand = new Random();
        public float x, y;
        public float initialX, initialY; // Store initial positions
        private int sqr = 20;
        public enum Direction { Up, Down, Left, Right }
        public Direction direction;

        public enum GhostMode
        {
            Scatter,
            Chase,
            Frightened
        }


        public IMoveBehaviour MoveBehaviour { get; set; }
        public GhostMode CurrentMode { get; set; }
        public string Identifier { get; set; }
        

        public Ghost(float x, float y, String identifier, Direction d)
        {
            isAlive = true;
            this.x = x;
            this.y = y;

            this.initialX = x;
            this.initialY = y;

            this.CurrentMode = GhostMode.Chase;
            this.Identifier = identifier;
            direction = d;
        }

        public void PerformMove(Map map)
        {
            MoveBehaviour.Move(this, map);
        }
        
        public void AnimGhost(Graphics g, int cntT, Brush ghostColor, Map map)
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
                    x = initialX; // Reset to exact initial position to avoid floating-point imprecision
                    y = initialY;
                    if (map.IsPassable((int)x, (int)y))
                    {
                        isAlive = true; // Respawn the ghost only if the initial position is passable
                    }
                }

            }
        }

        public void HandleBeingEaten()
        {
            this.isAlive = false;
        }


    }
}
