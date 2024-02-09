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
        public void Move(Ghost ghost, Map map, Canvas c)
        {
            Search search = new Search(map, ghost);
            Node nodoInicial = search.grid[(int)ghost.x, (int)ghost.y];
            Node nodoObjetivo = search.grid[map.pacman.X, map.pacman.Y];
            
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