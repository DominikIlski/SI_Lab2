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

        public VariableConstraint(int x, int y, int[] row, int[] column)
        {
            Domain = new HashSet<int>(Globals.ALL_POSSIBLE_VALUES);
            X = x;
            Y = y;

            var rowDomain = Globals.ALL_POSSIBLE_VALUES.Except(row).ToArray();

            var columnDomain = Globals.ALL_POSSIBLE_VALUES.Except(column);

            Domain.UnionWith(rowDomain);
            Domain.UnionWith(columnDomain);

            ConstraintsLevel = Domain.Count;

        }

        public int CompareTo([AllowNull] VariableConstraint other)
        {
            if (other is null) return 1;

            if (other != null) return ConstraintsLevel.CompareTo(other.ConstraintsLevel);
            else throw new Exception("Problem with CompareTo");
                
        }
    }
}
