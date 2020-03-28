using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver.Global
{
    static class Extensions
    {

        public static IEnumerable<T> SliceRow<T>(this T[,] array, int row)
        {
            for (var i = 0; i < array.GetLength(0); i++)
            {
                yield return array[i, row];
            }
        }

        public static IEnumerable<T> SliceColumn<T>(this T[,] array, int column)
        {
            for (var i = 0; i < array.GetLength(1); i++)
            {
                yield return array[column, i];
            }
        }


    }
}
