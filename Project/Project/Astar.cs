using System;
using System.Collections.Generic;

namespace Project
{
    public class Astar
    {
        public void AlgorithmAstar(Node[][] grid, Node startNode, Node endNode)
        {
            List<Node> openNodes=new List<Node>();
            openNodes.Add(startNode);
            startNode.Cost = 0;
            startNode.EstimatedCost = startNode.Cost+HeuristicFunction(startNode, endNode);
            while (openNodes.Count>0)
            {
                Node currentNode = MinNodeByEstimatedCost(openNodes);
                if (currentNode == endNode)
                {
                    return;
                }

                openNodes.Remove(currentNode);
                currentNode.Marked = true;
                Node neighbourUp = grid[currentNode.Y + 1][currentNode.X],
                    neighbourDown = grid[currentNode.Y - 1][currentNode.X],
                    neighbourRight = grid[currentNode.Y][currentNode.X+1],
                    neighbourLeft = grid[currentNode.Y][currentNode.X-1];

                #region checkNeigbours

                if (!neighbourDown.Barrier && !neighbourDown.Marked)
                {
                    if (!openNodes.Contains(neighbourDown))
                    {
                        neighbourDown.Cost = currentNode.Cost + 1;
                        neighbourDown.EstimatedCost = currentNode.Cost + 1 + HeuristicFunction(neighbourDown, endNode);
                        neighbourDown.Parent = currentNode;
                        openNodes.Add(neighbourDown);
                    }
                }
                
                if (!neighbourUp.Barrier && !neighbourUp.Marked)
                {
                    if (!openNodes.Contains(neighbourUp))
                    {
                        neighbourUp.Cost = currentNode.Cost + 1;
                        neighbourUp.EstimatedCost = currentNode.Cost + 1 + HeuristicFunction(neighbourUp, endNode);
                        neighbourDown.Parent = currentNode;
                        openNodes.Add(neighbourUp);
                    }
                }
                
                if (!neighbourRight.Barrier && !neighbourRight.Marked)
                {
                    if (!openNodes.Contains(neighbourRight))
                    {
                        neighbourRight.Cost = currentNode.Cost + 1;
                        neighbourRight.EstimatedCost = currentNode.Cost + 1 + HeuristicFunction(neighbourRight, endNode);
                        neighbourRight.Parent = currentNode;
                        openNodes.Add(neighbourRight);
                    }
                }
                
                if (!neighbourLeft.Barrier && !neighbourLeft.Marked)
                {
                    if (!openNodes.Contains(neighbourLeft))
                    {
                        neighbourLeft.Cost = currentNode.Cost + 1;
                        neighbourLeft.EstimatedCost = currentNode.Cost + 1 + HeuristicFunction(neighbourLeft, endNode);
                        neighbourLeft.Parent = currentNode;
                        openNodes.Add(neighbourLeft);
                    }
                }

                #endregion
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