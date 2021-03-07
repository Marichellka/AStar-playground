using System;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            Grid grid = new Grid(path);
            Astar astar=new Astar(grid);
            astar.Algorithm();
            grid.SetWayOnGrid(astar.Way);
            grid.PrintGrid(path);
        }
    }
}