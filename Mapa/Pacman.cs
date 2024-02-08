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

                // Platillo volador
                g.FillEllipse(Brushes.Silver, drawX, drawY + (sqr / 4), sqr, sqr / 2); // Cuerpo principal del platillo
                g.FillEllipse(Brushes.Gray, drawX + (sqr / 4), drawY, sqr / 2, sqr / 2); // Cúpula en la parte superior

                // Animación del fuego del escape
                Color fireColor;
                int fireHeight;
                switch (cntT % 3)
                {
                    case 0:
                        fireColor = Color.GreenYellow;
                        fireHeight = sqr / 4; // Fuego pequeño
                        break;
                    case 1:
                        fireColor = Color.Green;
                        fireHeight = sqr / 3; // Fuego mediano
                        break;
                    case 2:
                        fireColor = Color.DarkGreen;
                        fireHeight = sqr / 2; // Fuego grande
                        break;
                    default:
                        fireColor = Color.GreenYellow;
                        fireHeight = sqr / 4;
                        break;
                }

                // Posición y tamaño del fuego
                int fireX = drawX + sqr / 4;
                int fireY = drawY + sqr - fireHeight / 3;
                int fireWidth = sqr / 2;

                // Dibujo del fuego
                g.FillEllipse(new SolidBrush(fireColor), fireX, fireY, fireWidth, fireHeight);

                // Opcional: Dibujar varias llamas con diferentes colores y tamaños para un efecto más dinámico
                if ((cntT % 3) == 0)
                {
                    g.FillEllipse(Brushes.Green, fireX + fireWidth / 4, fireY - fireHeight / 4, fireWidth / 2, fireHeight * 2 / 3);
                }
                else if ((cntT % 3) == 1)
                {
                    g.FillEllipse(Brushes.DarkGreen, fireX + fireWidth / 4, fireY - fireHeight / 3, fireWidth / 2, fireHeight * 3 / 4);
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
