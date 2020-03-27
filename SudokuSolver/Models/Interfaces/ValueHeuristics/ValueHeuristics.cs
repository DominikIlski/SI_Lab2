using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver.Models.Interfaces.ValueHeuristics
{
    public abstract class ValueHeuristics
    {

        public abstract HashSet<int> Assume();

    }
}
