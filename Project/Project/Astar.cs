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
            return null;
        }
        public int HeuristicFunction(Node current, Node end)
        {
            return 0;
        }
    }
}