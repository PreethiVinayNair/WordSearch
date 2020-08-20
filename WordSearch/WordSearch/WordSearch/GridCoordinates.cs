using System;
using System.Collections.Generic;
using System.Text;

namespace WordSearch
{
    public class GridCoordinates
    {
        public GridCoordinates(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; set; }
        public int Column { get; set; }
    }
}
