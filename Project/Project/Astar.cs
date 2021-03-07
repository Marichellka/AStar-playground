using System;
using System.Collections.Generic;

namespace Project
{
    public class Astar
    {
        public void AlgorithmAstar(Node[][] grid, Node startNode, Node endNode)
        {
            List<Node> openNodes = new List<Node>();
            openNodes.Add(startNode);
            startNode.Cost = 0;
            startNode.EstimatedCost = startNode.Cost + HeuristicFunction(startNode, endNode);
            while (openNodes.Count > 0)
            {
                Node currentNode = MinNodeByEstimatedCost(openNodes);
                if (currentNode == endNode)
                {
                    return;
                }

                openNodes.Remove(currentNode);
                currentNode.Marked = true;
            }
        }
        
        public Node MinNodeByEstimatedCost(List<Node> openNodes)
        {
            Node minCostNode=openNodes[0];
            for (int i = 1; i < openNodes.Count; i++)
            {
                if (openNodes[i].EstimatedCost < minCostNode.EstimatedCost)
                {
                    minCostNode = openNodes[i];
                }
            }

            return minCostNode;
        }
        public int HeuristicFunction(Node current, Node end)
        {
            return Math.Abs(current.X - end.X) + Math.Abs(current.Y - end.Y);
        }
    }
}