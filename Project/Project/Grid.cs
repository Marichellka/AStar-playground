using System.Collections.Generic;
using System.IO;

namespace Project
{
    public class Grid
    {
        public List<Node[]> GetGrid(string path)
        {
            List<Node[]> grid = new List<Node[]>();
            using (var sr= new StreamReader(path))
            {
                int numberOfRow = 0;
                while (!sr.EndOfStream)
                {
                    string row = sr.ReadLine();
                    grid.Add(ConvertToNodesObj(row, numberOfRow));
                    numberOfRow++;
                }
            }

            return grid;
        }

        private Node[] ConvertToNodesObj(string str, int rowNumber)
        {
            Node[] currentRow = new Node[str.Length/2];
            for (int i = 0; i < str.Length; i ++)
            {
                currentRow[i/2] = new Node(i / 2, rowNumber, str[i]);
                i++;
            }
            return currentRow;
        }
    }
}