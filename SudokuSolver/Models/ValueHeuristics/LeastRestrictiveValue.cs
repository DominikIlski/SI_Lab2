using System;
using System.Collections.Generic;

namespace SudokuSolver.Models.ValueHeuristics
{
    public class LeastRestrictiveValue : ValueHeuristics
    {
        public override HashSet<T> Assume<T>(HashSet<T> possibleValues)
        {
            throw new NotImplementedException();
        }
    }
}