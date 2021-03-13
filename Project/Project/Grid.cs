﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Project
{
    public class Grid
    {
        public Node[][] NodeGrid { get; private set; }
        public List<char[]> CharsGrid { get;}
        public Node StartNode { get; set; }
        public Node EndNode { get; set; }
        
        public Grid(string path)
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
            CharsGrid = charGrid;
            ConvertGridToNodeGrid();
        }

       private void ConvertGridToNodeGrid()
        {
           Node[][] grid = new Node[CharsGrid.Count][];
            for (int i = 0; i < CharsGrid.Count; i++)
            {
                grid[i] = new Node[CharsGrid[i].Length];
                for (int j = 0; j < CharsGrid[i].Length; j++)
                {
                    grid[i][j]=new Node(j, i, CharsGrid[i][j]);
                }
            }
            NodeGrid = grid;
        }
       
       public void PrintCurrentState()
       {
           Thread.Sleep(500);
           Console.Clear();
           for (int i = 0; i < NodeGrid.Length; i++)
           {
               for (int j = 0; j < NodeGrid[i].Length; j++)
               {
                   Console.Write(NodeGrid[i][j].Sign+" ");
               }
               Console.WriteLine();
           }
       }

       public void PrintResult(string path)
       {
           using ( StreamWriter sw = new StreamWriter(path, true))
           {
               sw.WriteLine();
               Console.WriteLine();
               for (int i = 0; i < CharsGrid.Count; i++)
               {
                   for (int j = 0; j < CharsGrid[i].Length; j++)
                   {
                       Console.Write(CharsGrid[i][j]+" ");
                       sw.Write(CharsGrid[i][j]+" ");
                   }
                   Console.WriteLine();
                   sw.WriteLine();
               }
           }
       }
    }
}