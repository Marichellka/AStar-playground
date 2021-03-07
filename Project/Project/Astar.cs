using System;
using System.Collections.Generic;

namespace Project
{
    public class Astar
    {
        public Grid Grid { get;}
        private List<Node> OpenNodes;
        public List<Node> Way { get; private set; }
        
        public Astar(Grid grid)
        {
            Grid=grid;
        }
        
        public void Algorithm()
        {
            OpenNodes.Add(Grid.StartNode);
            Grid.StartNode.Cost = 0;
            Grid.StartNode.EstimatedCost = Grid.StartNode.Cost+HeuristicFunction(Grid.StartNode, Grid.EndNode);
            while (OpenNodes.Count>0)
            {
                Node currentNode = MinNodeByEstimatedCost();
                if (currentNode == Grid.EndNode)
                {
                    return;
                }

                OpenNodes.Remove(currentNode);
                currentNode.Marked = true;
                Node[] neighbours = new[]
                {
                    Grid.NodeGrid[currentNode.Y + 1][currentNode.X],
                    Grid.NodeGrid[currentNode.Y - 1][currentNode.X],
                    Grid.NodeGrid[currentNode.Y][currentNode.X + 1],
                    Grid.NodeGrid[currentNode.Y][currentNode.X - 1]
                };

                foreach (var neighbour in neighbours)
                {
                    CheckNeigbour(neighbour, currentNode);
                }
            }
        }

        private void CheckNeigbour(Node neighbour, Node currentNode)
        {
            if (!neighbour.Barrier && !neighbour.Marked)
            {
                if (!OpenNodes.Contains(neighbour))
                {
                    neighbour.Cost = currentNode.Cost + 1;
                    neighbour.EstimatedCost = currentNode.Cost + 1 + HeuristicFunction(neighbour, Grid.EndNode);
                    neighbour.Parent = currentNode;
                    OpenNodes.Add(neighbour);
                }
            }
        }
        
        private Node MinNodeByEstimatedCost()
        {
            Node minCostNode=OpenNodes[0];
            for (int i = 1; i < OpenNodes.Count; i++)
            {
                if (OpenNodes[i].EstimatedCost < minCostNode.EstimatedCost)
                {
                    minCostNode = OpenNodes[i];
                }
            }

            return minCostNode;
        }

        private int HeuristicFunction(Node current, Node end)
        {
            return Math.Abs(current.X - end.X) + Math.Abs(current.Y - end.Y);
        }
        
        public void GetWay()
        {
            Node current = Grid.EndNode;
            Way = new List<Node>();
            while (current.Parent != null)
            {
                Way.Add(current);
                current = current.Parent;
            }
        }
    }
}