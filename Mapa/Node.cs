using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapa
{
    public class Node
    {
        public bool IsWall { get; set; }
        public Node Parent { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int G { get; set; }
        public int H { get; set; }
        public int F { get { return G + H; } }

        public Node(bool isWall, int x, int y)
        {
            this.IsWall = isWall;
            this.X = x;
            this.Y = y;
        }
    }
}
