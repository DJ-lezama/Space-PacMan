using System;
using System.Collections.Generic;
using PacMan;

namespace Mapa
{
    public class PinkyChaseMode : IMoveBehaviour
    {
        Node nodoObjetivo;
        int newX, newY;
        public void Move(Ghost ghost, Map map, Canvas c)
        {
            Search search = new Search(map, ghost);
            Node nodoInicial = search.grid[(int)ghost.x, (int)ghost.y];

            switch (map.pacman.CurrentDirection)
            {
                case Pacman.Direction.Left:
                    newX = Math.Max(map.pacman.X - 4, 0); // Asegura que newX no sea menor que 0
                    newY = map.pacman.Y;
                    break;
                case Pacman.Direction.Right:
                    newX = Math.Min(map.pacman.X + 4, map.level.GetLength(1) - 1); // Asegura que newX no exceda el máximo índice en X
                    newY = map.pacman.Y;
                    break;
                case Pacman.Direction.Up:
                    newX = map.pacman.X;
                    newY = Math.Max(map.pacman.Y - 4, 0); // Asegura que newY no sea menor que 0
                    break;
                case Pacman.Direction.Down:
                    newX = map.pacman.X;
                    newY = Math.Min(map.pacman.Y + 4, map.level.GetLength(0) - 1); // Asegura que newY no exceda el máximo índice en Y
                    break;
                default:
                    newX = map.pacman.X; // Mantén la posición actual si la dirección no es válida
                    newY = map.pacman.Y;
                    break;
            }

            // Ahora newX y newY están dentro de los límites, así que puedes acceder de forma segura a grid
            nodoObjetivo = search.grid[newX, newY];

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