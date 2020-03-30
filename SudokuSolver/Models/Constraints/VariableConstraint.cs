using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using SudokuSolver.Global;

namespace SudokuSolver.Models.VariableHeuristics
{
    public class VariableConstraint : IComparable<VariableConstraint>
    {

        public int X { set; get; }
        public int Y { set; get; }
        public int ConstraintsLevel { set; get; }
        public HashSet<int> Domain { set; get; }
        

        public VariableConstraint(int x, int y, Sudoku currentExample)
        {
            Domain = new HashSet<int>(Globals.ALL_POSSIBLE_VALUES);
            X = x;
            Y = y;

            var row = currentExample.Grid.SliceRow(y).ToArray();
            var column = currentExample.Grid.SliceColumn(x).ToArray();

            var subGrid = CheckSubGrid(y, x, currentExample);

            var rowDomain = Globals.ALL_POSSIBLE_VALUES.Except(row).ToArray();

            var columnDomain = Globals.ALL_POSSIBLE_VALUES.Except(column);

            var subGridDomain = Globals.ALL_POSSIBLE_VALUES.Except(subGrid);

            var subDomain = rowDomain.Intersect(columnDomain);

            var domain = subDomain.Intersect(subGridDomain);
             
            Domain = new HashSet<int>(domain);

            ConstraintsLevel = Domain.Count;

        }

        public int CompareTo([AllowNull] VariableConstraint other)
        {
            if (other is null) return 1;

            if (other != null) return ConstraintsLevel.CompareTo(other.ConstraintsLevel);
            else throw new Exception("Problem with CompareTo");
                
        }



        private HashSet<int> CheckSubGrid(int row, int column, Sudoku sudoku)
        {
            
            var domain = new HashSet<int>();
            
            var boxRowStart = (int)Math.Floor((double)(row/3)) * 3;
            var boxColStart = (int)Math.Floor((double)(column / 3)) * 3;



            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    domain.Add(sudoku[boxColStart + i, boxRowStart + j]);
                }

            return domain;
        }
    }
}

