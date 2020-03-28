using SudokuSolver.Models.Interfaces;
using System;

namespace SudokuSolver.Models
{
    public class Sudoku : ICacheMultiple<int>
    {
        public int[,] Grid {private set; get; }
        private TimeSpan? SolveingTime { set; get; }
        private int? SolutionNumber { set; get; }
        private int? NodeVisited { set; get; }

        public Sudoku(int[,] grid)
        {
            Grid = (int[,])grid.Clone();
        }

        public int this[int xKey, int yKey]
        {
            get => Grid[xKey, yKey];
            set => Grid[xKey, yKey] = value;
        }
    }
}