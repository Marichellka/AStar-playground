using System.Collections.Generic;
using System.IO;

namespace Project
{
    public class Grid
    {
        public List<char[]> GetGrid(string path) 
        {
            List<char[]> charGrid = new List<char[]>();
            using (var sr= new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string row = sr.ReadLine();
                    char[] currentRow = new char[row.Length/2];
                    for (int i = 0; i < row.Length; i+=2)
                    {
                        currentRow[i/2] = row[i];
                    }
                    charGrid.Add(currentRow);
                }
            }
            return charGrid;
        }
        private Node[][] ConvertGridToNodeGrid(List<char[]> charGrid)
        {
            Node[][] grid = new Node[charGrid.Count][];
            for (int i = 0; i < charGrid.Count; i++) 
            {
                grid[i] = new Node[charGrid[i].Length];
                for (int j = 0; j < charGrid[i].Length; j++)
                {
                            grid[i][j]=new Node(j, i, charGrid[i][j]);
                }
            }
            return grid;
        }
        
        public static List<Node> GetWay(Node endNode)
        {
            Node current = endNode;
            List<Node> way = new List<Node>();
            while (current.Parent != null)
            {
                way.Add(current);
                current = current.Parent;
            }

            return way;
        }
        
        public static void SetWayOnGrid(List<char[]> grid, List<Node> way)
        {
            foreach (var currentNode in way)
            {
                grid[currentNode.Y][currentNode.X] = '*';
            }
        }
    }
}