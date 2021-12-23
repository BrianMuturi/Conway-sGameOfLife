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
      
        public  int x;
        public int y;
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
        public bool[,] NewGeneration(bool[,] grid)
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
        public int GetAliveNeighboursCount(int x, int y, bool[,] grid)
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
        public Generation(int initialAliveCellsCount )
        {
        
        }

        // population density
        public Generation(bool[,] grid,int initialAliveCellsCount):this(initialAliveCellsCount)
        {
            double density;
            this.grid = grid;
            Random generator = new Random();
            density = (initialAliveCellsCount * 100) / 900;
            Console.WriteLine(density);

           for (int i = 0; i < density; i++)
            {
                 x = generator.Next(30);
                 y = generator.Next(30);
                Putters[generator.Next(Putters.Length)](grid, x, y);
            } 
        }

        //String constructor
        public Generation(Generation bri, string p)
        {
            this.x = bri.x;
            this.y = bri.y;
            this.grid = bri.grid;
            //Console.Clear();
            int aliveCells = 0;
            for (int x = 0; x < 30; x++)
            {
                for (int y = 0; y < 30; y++)
                {
                    Console.Write(grid[x, y] ? p : ".");
                    if (grid[x, y])
                        aliveCells++;
                }
                Console.WriteLine("");
            }
            Console.WriteLine($"Alive cells: {aliveCells}");
            
        }
        //== override method for grid
        /*public override bool Equals(object obj)
         {
             return base.Equals(obj);
         }*/

        //To string method
   
        public override string ToString()
        {
            return base.ToString();
        }
     
        //shapes of the cells
        public static void PutGlider(bool[,] grid, int x, int y)
        {
            int n = 30;
            grid[x, (y - 1 + n) % n] = true;
            grid[(x + 1) % n, y] = true;
            grid[(x - 1 + n) % n, (y + 1) % n] = true;
            grid[x, (y + 1) % n] = true;
            grid[(x + 1) % n, (y + 1) % n] = true;
        }
        public static void PutBlock(bool[,] grid, int x, int y)
        {
            int n = 30;
            grid[x, y] = true;
            grid[(x + 1) % n, y] = true;
            grid[x, (y + 1) % n] = true;
            grid[(x + 1) % n, (y + 1) % n] = true;
        }
        public static void PutTub(bool[,] grid, int x, int y)
        {
            int n = 30;
            grid[(x - 1 + n) % n, y] = true;
            grid[(x + 1) % n, y] = true;
            grid[x, (y - 1 + n) % n] = true;
            grid[x, (y + 1) % n] = true;
        }
    }
}
