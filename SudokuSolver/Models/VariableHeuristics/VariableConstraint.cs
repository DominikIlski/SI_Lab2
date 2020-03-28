using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using SudokuSolver.Global;

namespace SudokuSolver.Models.VariableHeuristics
{
    class VariableConstraint : IComparable<VariableConstraint>
    {
        
        int X { set; get; }
        int Y { set; get; }
        int Constraints { set; get; }
        HashSet<int> Domain { set; get; }

        public VariableConstraint(int x, int y, int[] row, int[] column)
        {
            Domain = new HashSet<int>(Globals.ALL_POSSIBLE_VALUES);
            X = x;
            Y = y;

            var rowDomain = Globals.ALL_POSSIBLE_VALUES.Except(row);

            var columnDomain = Globals.ALL_POSSIBLE_VALUES.Except(column);

            Domain.UnionWith(rowDomain);
            Domain.UnionWith(columnDomain);

            Constraints = Domain.Count;

        }

        public int CompareTo([AllowNull] VariableConstraint other)
        {
            if (other is null) return 1;

            if (other != null) return Constraints.CompareTo(other.Constraints);
            else throw new Exception("Problem with CompareTo");
                
        }
    }
}
