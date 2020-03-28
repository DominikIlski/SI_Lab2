using System.Collections.Generic;

namespace SudokuSolver.Models.ValueHeuristics
{
    public abstract class ValueHeuristics
    {
        public abstract HashSet<T> Assume<T>(HashSet<T> possibleValues);
    }
}