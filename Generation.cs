using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway_sGameOfLife
{
    class Generation : Cells
    {
        public override void SetCell(bool[,] grid, int x, int y)
        {
            grid[x, y] = true;
        }
        public  Generation(bool[,] grid, int x,int y)
        {
            bool[,] generation = new bool[20, 20];
            Console.WriteLine("Welcome to Convay’s Game of Life!");
            Console.Write("How many random alive cells should be placed: ");
            int initialAliveCellsCount = Convert.ToInt32(Console.ReadLine()); 
        }
    }
}
