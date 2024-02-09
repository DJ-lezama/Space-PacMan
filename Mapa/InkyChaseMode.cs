using System;
using System.Collections.Generic;
using PacMan;

namespace Mapa
{
    public class InkyChaseMode : IMoveBehaviour
    {
        Node nodoObjetivo, bl;
        Ghost gh;
        int dpaX, dpaY;
        bool p;

        public void Move(Ghost ghost, Map map, Canvas c)
        {
            gh = BlinkyChaseMode.g;
            Search search = new Search(map, ghost);
            Node nodoInicial = search.grid[(int)ghost.x, (int)ghost.y];

            switch (map.pacman.CurrentDirection)
            {
                case Pacman.Direction.Left:
                    dpaX = Math.Max(map.pacman.X - 2, 0); // Asegura que dpaX no sea menor que 0
                    dpaY = map.pacman.Y;
                    break;
                case Pacman.Direction.Right:
                    dpaX = Math.Min(map.pacman.X + 2, search.grid.GetLength(1) - 1); // Asegura que dpaX no exceda el máximo índice en X
                    dpaY = map.pacman.Y;
                    break;
                case Pacman.Direction.Up:
                    dpaX = map.pacman.X;
                    dpaY = Math.Max(map.pacman.Y - 2, 0); // Asegura que dpaY no sea menor que 0
                    break;
                case Pacman.Direction.Down:
                    dpaX = map.pacman.X;
                    dpaY = Math.Min(map.pacman.Y + 2, search.grid.GetLength(0) - 1); // Asegura que dpaY no exceda el máximo índice en Y
                    break;
                default:
                    dpaX = map.pacman.X; // Mantén la posición actual si la dirección no es válida
                    dpaY = map.pacman.Y;
                    break;
            }

            bl = search.grid[dpaX - (int)gh.x, dpaY - (int)gh.y];
            p = map.IsPassable(bl.X, bl.Y);

            if (p == false)
            {

            }
            else
            {
                nodoObjetivo = search.grid[dpaX + bl.X, dpaY + bl.Y];
            }
            // Ahora newX y newY están dentro de los límites, así que puedes acceder de forma segura a grid

            List<Node> camino = search.FindPath(nodoInicial, nodoObjetivo);

            if (camino != null && camino.Count > 0)
            {
                // Mover al fantasma al siguiente nodo en el camino, ignorando el primer nodo que es la posición actual del fantasma
                Node siguienteNodo = camino.Count == 1 ? camino[0] : camino[1];
                ghost.x = siguienteNodo.X;
                ghost.y = siguienteNodo.Y;
            }
        }
    }
}