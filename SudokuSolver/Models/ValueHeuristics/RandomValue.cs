using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver.Models.ValueHeuristics
{
    public class RandomValue : ValueHeuristics
    {
        public override HashSet<T> Assume<T>(HashSet<T> possibleValues)
        {
            throw new NotImplementedException();
        }
    }
}
