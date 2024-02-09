using PacMan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapa
{
    public class Search
    {
        public Node[,] grid;
        private List<Node> openList;
        private HashSet<Node> closedList;

        public Search(Map m)
        {
            grid = new Node[m.level.GetLength(1), m.level.GetLength(0)];
            openList = new List<Node>();
            closedList = new HashSet<Node>();

            // Inicializar la cuadrícula con los nodos que son transitables)
            for (int y = 0; y < m.level.GetLength(0); y++)
            {
                for (int x = 0; x < m.level.GetLength(1); x++)
                {
                    if (m.level[y, x] == '0')
                    {
                        grid[x, y] = new Node(true, x, y);
                    }
                    else
                    {
                        grid[x, y] = new Node(false, x, y);
                    }
                }
            }
        }

        public List<Node> FindPath(Node startNode, Node endNode)
        {
            openList.Add(startNode);

            while (openList.Count > 0)
            {
                Node currentNode = openList[0];
                for (int i = 1; i < openList.Count; i++)
                {
                    if (openList[i].F < currentNode.F || openList[i].F == currentNode.F && openList[i].H < currentNode.H)
                    {
                        currentNode = openList[i];
                    }
                }

                openList.Remove(currentNode);
                closedList.Add(currentNode);

                if (currentNode == endNode)
                {
                    return RetracePath(startNode, endNode);
                }

                foreach (Node neighbour in GetNeighbours(currentNode))
                {
                    if (neighbour.IsWall || closedList.Contains(neighbour))
                    {
                        continue;
                    }

                    int newMovementCostToNeighbour = currentNode.G + GetDistance(currentNode, neighbour);
                    if (newMovementCostToNeighbour < neighbour.G || !openList.Contains(neighbour))
                    {
                        neighbour.G = newMovementCostToNeighbour;
                        neighbour.H = GetDistance(neighbour, endNode);
                        neighbour.Parent = currentNode;

                        if (!openList.Contains(neighbour))
                            openList.Add(neighbour);
                    }
                }
            }

            return null;
        }

        private List<Node> RetracePath(Node startNode, Node endNode)
        {
            List<Node> path = new List<Node>();
            Node currentNode = endNode;

            while (currentNode != startNode)
            {
                path.Add(currentNode);
                currentNode = currentNode.Parent;
            }
            path.Reverse();
            return path;
        }

        private List<Node> GetNeighbours(Node node)
        {
            List<Node> neighbours = new List<Node>();

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0)
                        continue;

                    int checkX = node.X + x;
                    int checkY = node.Y + y;

                    if ((checkX >= 0 && checkX < grid.GetLength(1) && checkY >= 0 && checkY < grid.GetLength(0)) || grid[checkX,checkY].IsWall != true)
                    {
                        neighbours.Add(grid[checkX, checkY]);
                    }
                }
            }

            return neighbours;
        }

        private int GetDistance(Node nodeA, Node nodeB)
        {
            int distX = Math.Abs(nodeA.X - nodeB.X);
            int distY = Math.Abs(nodeA.Y - nodeB.Y);

            return 20 * (distX + distY); ;
        }
    }
}
