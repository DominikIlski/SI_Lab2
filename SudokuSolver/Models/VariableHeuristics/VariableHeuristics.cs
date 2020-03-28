using System.Collections.Generic;

namespace SudokuSolver.Models.VariableHeuristics
{
    internal abstract class VariableHeuristics
    {
        public abstract HashSet<int> Assume(Sudoku sudoku);
    }
}