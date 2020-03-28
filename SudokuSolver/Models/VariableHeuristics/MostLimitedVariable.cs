using SudokuSolver.Global;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SudokuSolver.Models.VariableHeuristics
{
    public class MostLimitedVariable : VariableHeuristics
    {
        public override List<VariableConstraint> Assume(Sudoku sudoku)
        {
            var solvingOrder = new List<VariableConstraint>();
            var grid = sudoku.Grid;
            for (int i = 0; i < Globals.SUDOKU_SIZE; i++)
            {
                for (int j = 0; j < Globals.SUDOKU_SIZE; j++)
                {
                    if(sudoku[j,i] == 0)
                    solvingOrder.Add(new VariableConstraint(j, i, grid.SliceRow(i).ToArray(), 
                        grid.SliceColumn(j).ToArray()));
                }
            }

            solvingOrder.Sort();

            return solvingOrder;
        }
    }
}