using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PacMan;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Mapa
{
    public class BlinkyChaseMode : IMoveBehaviour
    {
        Search s;

        public void Move(Ghost ghost, Map map, Canvas c)
        {
            s = new Search(map);
            Node nodoInicial = s.grid[(int)ghost.x, (int)ghost.y];
            Node nodoObjetivo = s.grid[map.pacman.X, map.pacman.Y];

            switch (ghost.direction)
            {
                case Ghost.Direction.Up:
                    ghost.direction = Ghost.Direction.Down;
                    break;
                case Ghost.Direction.Down:
                    ghost.direction = Ghost.Direction.Up;
                    break;
                case Ghost.Direction.Right:
                    ghost.direction = Ghost.Direction.Left;
                    break;
                case Ghost.Direction.Left:
                    ghost.direction = Ghost.Direction.Right;
                    break;
            }

            List<Node> camino = s.FindPath(nodoInicial, nodoObjetivo);

            if (camino != null && camino.Count > 1)
            {
                // Mover al fantasma al siguiente nodo en el camino, ignorando el primer nodo que es la posición actual del fantasma
                Node siguienteNodo = camino[1];
                ghost.x = siguienteNodo.X;
                ghost.y = siguienteNodo.Y;
            }
        }
    }
}