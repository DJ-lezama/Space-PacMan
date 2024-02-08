using System;
using System.Drawing;

namespace PacMan
{
    public class Pacman
    {
        
        public int sqr = 20;
        public int X { get; set; }
        public int Y { get; set; }
        public enum Direction { Up, Down, Left, Right }
        public Direction CurrentDirection { get; set; }
        public Boolean poweredUp;
        public Boolean isAlive;
        public int lives = 3;

        public Pacman(int startX, int startY, int squareSize)
        {
            this.X = startX;
            this.Y = startY;
            this.sqr = squareSize;
            this.poweredUp = false;
            this.isAlive = true;
        }

        public void PacmanMove(Map map)
        {
            int newX = X;
            int newY = Y;

            switch (CurrentDirection)
            {
                case Direction.Left:
                    newX -= 1;
                    break;
                case Direction.Right:
                    newX += 1;
                    break;
                case Direction.Up:
                    newY -= 1;
                    break;
                case Direction.Down:
                    newY += 1;
                    break;
            }

            // Check if the new position is passable before moving.
            if (map.IsPassable(newX, newY))
            {
                X = newX;
                Y = newY;
            }

            // Check and eat the pill or power pellet at the new position.
            map.EatPillOrPellet(newX, newY, this);
        }
        public void Anim(Graphics g, int cntT)
        {
            int drawX = X * sqr;
            int drawY = Y * sqr;
            int startAngle, sweepAngle;

            if (this.isAlive)
            {
                // Determine the start angle and sweep angle based on current direction
                switch (CurrentDirection)
                {
                    case Direction.Right:
                        startAngle = 30; // Start drawing from 30 degrees for right movement
                        sweepAngle = 300; // Sweep 300 degrees
                        break;
                    case Direction.Left:
                        startAngle = 210; // Start drawing from 210 degrees for left movement
                        sweepAngle = 300;
                        break;
                    case Direction.Down:
                        startAngle = 120; // Start drawing from 120 degrees for up movement
                        sweepAngle = 300;
                        break;
                    case Direction.Up:
                        startAngle = 300; // Start drawing from 300 degrees for down movement
                        sweepAngle = 300;
                        break;
                    default:
                        startAngle = 0;
                        sweepAngle = 360; // Full circle if direction is unknown
                        break;
                }

                // Adjust drawing based on the animation frame
                switch (cntT % 6)
                {
                    case 0:
                    case 1:
                    case 5:
                        g.FillEllipse(Brushes.Yellow, drawX, drawY, sqr, sqr);
                        break;
                    case 2:
                    case 4:
                        g.FillPie(Brushes.Yellow, drawX, drawY, sqr, sqr, startAngle, sweepAngle);
                        break;
                    case 3:
                        // Adjust the start angle and sweep angle for a "mouth open" effect
                        g.FillPie(Brushes.Yellow, drawX, drawY, sqr, sqr, startAngle + 15, sweepAngle - 30);
                        break;
                }

                // Draw eyes only when Pac-Man is visible and not in the "fully closed mouth" state
                if (cntT % 6 != 0)
                {
                    // Adjust eye position based on direction
                    int eyeX = drawX + (sqr / 3);
                    int eyeY = drawY + (sqr / 3);
                    if (CurrentDirection == Direction.Left || CurrentDirection == Direction.Right)
                    {
                        eyeY -= sqr / 8;
                    }
                    else if (CurrentDirection == Direction.Up || CurrentDirection == Direction.Down)
                    {
                        eyeX -= sqr / 8;
                    }
                    g.FillEllipse(Brushes.Black, eyeX, eyeY, sqr / 5, sqr / 5);
                }
            }
            else
            {
                switch ((cntT / 4) % 7)
                {
                    case 0:
                        g.FillEllipse(Brushes.DarkSeaGreen, drawX, drawY, sqr, sqr);
                        break;
                    case 1:
                    case 2:
                        g.FillPie(Brushes.DarkSeaGreen, drawX, drawY, sqr, sqr, 30, 300);
                        break;
                    case 3:
                        g.FillPie(Brushes.DarkSeaGreen, drawX, drawY, sqr, sqr, 45, 240);
                        break;
                    case 4:
                        g.FillPie(Brushes.DarkSeaGreen, drawX, drawY, sqr, sqr, 50, 180);
                        break;
                    case 5:
                        g.FillPie(Brushes.DarkSeaGreen, drawX, drawY, sqr, sqr, 55, 120);
                        break;
                    case 6:
                        g.FillPie(Brushes.DarkSeaGreen, drawX, drawY, sqr, sqr, 60, 60);
                        break;
                    case 7:
                        g.FillPie(Brushes.DarkSeaGreen, drawX, drawY, sqr, sqr, 65, 0);
                        break;
                }             
            }
        }

       public void HandleBeingEaten()
       {
            this.isAlive = false;
            this.lives --; //update lives left
       }

    }
}
