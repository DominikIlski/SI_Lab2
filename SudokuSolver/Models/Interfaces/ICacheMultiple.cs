using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver.Models.Interfaces
{
    public interface ICacheMultiple<TContent>
    {
        
        TContent this[int xKey, int yKey] { get; set; }

    }
}
