using System.Collections.Generic;

namespace SudokuSolver.Models.Interfaces.ValueHeuristics
{
    public abstract class ValueHeuristics
    {
        public abstract HashSet<int> Assume();
    }
}