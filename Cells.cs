using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway_sGameOfLife
{
   abstract class Cells
    {
        public abstract void SetCell(bool[,] grid, int x, int y);
    }
}
