using System.Collections.Generic;

namespace SudokuSolver.Models.VariableHeuristics
{
    public abstract class VariableHeuristics
    {
        public abstract List<VariableConstraint> Assume(Sudoku sudoku);
    }
}