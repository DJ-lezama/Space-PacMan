using PacMan;
using System;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Mapa
{
    public class ClydeChaseMode  : IMoveBehaviour
    {
        Node nodoObjetivo;
        int distancia;
        public void Move(Ghost ghost, Map map, Canvas c)
        {
            Search search = new Search(map, ghost);
            Node nodoInicial = search.grid[(int)ghost.x, (int)ghost.y];

            distancia = Math.Abs((int)ghost.x - map.pacman.X) + Math.Abs((int)ghost.y - map.pacman.Y);


            if (distancia < 8)
            {
                // Si Clyde está a menos de 8 espacios de Pac-Man, se dirige hacia su "casa" o un punto fijo
                nodoObjetivo = search.grid[search.chomex, search.chomey];
            }
            else
            {
                // Si Clyde está a 8 o más espacios de distancia, persigue a Pac-Man
                nodoObjetivo = search.grid[map.pacman.X, map.pacman.Y];
            }

            List<Node> camino = search.FindPath(nodoInicial, nodoObjetivo);

            if (camino != null && camino.Count > 0)
            {
                // Mover al fantasma al siguiente nodo en el camino, ignorando el primer nodo que es la posición actual del fantasma
                Node siguienteNodo = camino.Count == 1 ? camino[0] : camino[1];
                ghost.x = siguienteNodo.X;
                ghost.y = siguienteNodo.Y;
            }
            
            ghost.UpdateDirection((int)ghost.x, (int)ghost.y);
        }
    }
}