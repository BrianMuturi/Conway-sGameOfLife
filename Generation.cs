using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway_sGameOfLife
{
    class Generation : Cells
    {
        public bool[,] grid;
        public int x, y;
        public int initialAliveCellsCount;
        delegate void PutShape(bool[,] grid, int x, int y);
        static PutShape[] Putters = new PutShape[]
        {
            PutGlider, PutBlock, PutTub
        };

        //initialising the cell state
        public override void SetCell(bool[,] grid, int x, int y)
        {
            grid[x, y] = true;
        }

        //generating the board after passing no of simulation steps
        private static bool[,] NewGeneration(bool[,] grid)
        {
            bool[,] newGrid = new bool[30, 30];
            for (int x = 0; x < 30; x++)
            {
                for (int y = 0; y < 30; y++)
                {
                    int AliveNeighbours = GetAliveNeighboursCount(x, y, grid);
                    if (grid[x, y] == true)
                    {
                        newGrid[x, y] = AliveNeighbours == 2 || AliveNeighbours == 3;
                    }
                    else
                    {
                        newGrid[x, y] = AliveNeighbours == 3;
                    }
                }

            }
            return newGrid;
        }

        //Logic of alive neighbors
        public static int GetAliveNeighboursCount(int x, int y, bool[,] grid)
        {
            int count = 0;
            int n = 30;
            if (grid[(x - 1 + n) % n, (y - 1 + n) % n] == true)
                count++;
            if (grid[x, (y - 1 + n) % n] == true)
                count++;
            if (grid[(x + 1) % n, (y - 1 + n) % n] == true)
                count++;
            if (grid[(x - 1 + n) % n, y] == true)
                count++;
            if (grid[(x + 1) % n, y] == true)
                count++;
            if (grid[(x - 1 + n) % n, (y + 1) % n] == true)
                count++;
            if (grid[x, (y + 1) % n] == true)
                count++;
            if (grid[(x + 1) % n, (y + 1) % n] == true)
                count++;
            return count;
        }

        //Generating the grid
        public Generation()
        {
           
            Console.WriteLine("Welcome to Convay’s Game of Life!");
            Console.Write("How many random alive cells should be placed: ");
            initialAliveCellsCount = Convert.ToInt32(Console.ReadLine());

        }

        // population density
        public Generation(bool[,] grid, int x, int y)
        {
            this.grid = grid;
            Random generator = new Random();
            double density = (initialAliveCellsCount * 100) / 400;
            Console.WriteLine(density);

           for (int i = 0; i < density; i++)
            {
                // x = generator.Next(30);
                 // y = generator.Next(30);
                Putters[generator.Next(Putters.Length)](grid, x, y);
            } 
        }

        //shapes of the cells
        private static void PutGlider(bool[,] grid, int x, int y)
        {
            int n = 30;
            grid[x, (y - 1 + n) % n] = true;
            grid[(x + 1) % n, y] = true;
            grid[(x - 1 + n) % n, (y + 1) % n] = true;
            grid[x, (y + 1) % n] = true;
            grid[(x + 1) % n, (y + 1) % n] = true;
        }
        private static void PutBlock(bool[,] grid, int x, int y)
        {
            int n = 30;
            grid[x, y] = true;
            grid[(x + 1) % n, y] = true;
            grid[x, (y + 1) % n] = true;
            grid[(x + 1) % n, (y + 1) % n] = true;
        }
        private static void PutTub(bool[,] grid, int x, int y)
        {
            int n = 30;
            grid[(x - 1 + n) % n, y] = true;
            grid[(x + 1) % n, y] = true;
            grid[x, (y - 1 + n) % n] = true;
            grid[x, (y + 1) % n] = true;
        }
    }
}
