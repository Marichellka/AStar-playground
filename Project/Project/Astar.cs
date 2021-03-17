using System;
using System.Collections.Generic;

namespace Project
{
    public class Astar
    {
        public Grid Grid { get;}
        private PriorityQueue<Node> OpenNodes;
        public List<Node> Way { get; private set; }
        
        public Astar(Grid grid)
        {
            Grid=grid;
        }
        
        public void Algorithm()
        {
            OpenNodes = new PriorityQueue<Node>();
            OpenNodes.Add(Grid.StartNode, Grid.StartNode.EstimatedCost);
            Grid.StartNode.Cost = 0;
            Grid.StartNode.EstimatedCost = Grid.StartNode.Cost+HeuristicFunction(Grid.StartNode, Grid.EndNode);
            while (OpenNodes.Count>0)
            {
                Node currentNode = OpenNodes.Top();
                currentNode.Marked = true;
                Grid.PrintCurrentState();
                if (currentNode == Grid.EndNode)
                {
                    break;
                }
                Node[] neighbours = new[]
                {
                    Grid.NodeGrid[currentNode.Y][currentNode.X + 1],
                    Grid.NodeGrid[currentNode.Y + 1][currentNode.X],
                    Grid.NodeGrid[currentNode.Y][currentNode.X - 1],
                    Grid.NodeGrid[currentNode.Y - 1][currentNode.X]
                };

                foreach (var neighbour in neighbours)
                {
                    CheckNeigbour(neighbour, currentNode);
                }
            }
            GetWay();
        }

        private void CheckNeigbour(Node neighbour, Node currentNode)
        {
            if (!neighbour.Barrier && !neighbour.Marked)
            {
                if (!OpenNodes.Contains(neighbour, neighbour.EstimatedCost))
                {
                    neighbour.Cost = currentNode.Cost + 1;
                    neighbour.EstimatedCost = currentNode.Cost + 1 + HeuristicFunction(neighbour, Grid.EndNode);
                    neighbour.Parent = currentNode;
                    OpenNodes.Add(neighbour, neighbour.EstimatedCost);
                }
            }
        }

        private int HeuristicFunction(Node current, Node end)
        {
            return Math.Abs(current.X - end.X) + Math.Abs(current.Y - end.Y);
        }
        
        private void GetWay()
        {
            Node current = Grid.EndNode;
            Way = new List<Node>();
            while (current != null)
            {
                Way.Add(current);
                current = current.Parent;
            }
        }
    }
}