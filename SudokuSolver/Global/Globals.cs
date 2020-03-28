using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver.Global
{
    public static class Globals
    {
        public readonly static string FILEPATH_ERROR = "Problem With filePath";
        public readonly static string FILEPATH_DEFAULT_SUDOKU = "D:\\gitProjects\\SI_Lab2\\" +
            "SudokuSolver\\Resources\\Sudoku.csv";
        public static readonly int[] ALL_POSSIBLE_VALUES = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public static readonly int SUDOKU_SIZE = 9;

    }
}
