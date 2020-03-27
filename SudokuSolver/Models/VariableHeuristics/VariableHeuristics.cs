using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver.Models.VariableHeuristics
{
    abstract class VariableHeuristics
    {


        public abstract HashSet<int> Assume();


    }
}
