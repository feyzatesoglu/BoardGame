using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame
{
    class Cell
    {
        public int RowNumber { get; set; }
        public int ColNumber { get; set; }
        public bool CurrentlyOccupied { get; set; }
        public bool LegalNextMove { get; set; }

        public Cell(int x, int y)
        {
            RowNumber = x;
            ColNumber = y;
        }
    }
}
