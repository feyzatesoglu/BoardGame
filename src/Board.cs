using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame
{
    class Board
    {
        public int Size { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public Cell[,] theGrid { get; set; }
        public Board(int r,int c)
        {
            Row = r;
            Col = c;
            theGrid = new Cell[r, c];
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }

        }
    }
}
