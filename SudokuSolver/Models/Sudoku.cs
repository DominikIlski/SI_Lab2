using SudokuSolver.Global;
using SudokuSolver.Models.Interfaces;
using System;

namespace SudokuSolver.Models
{
    public class Sudoku : ICacheMultiple<int>
    {
        public int[,] Grid {private set; get; }
        //private TimeSpan? SolveingTime { set; get; }
        //private int? SolutionNumber { set; get; }
        //private int? NodeVisited { set; get; }


        public Sudoku(Sudoku other)
        {
            Grid = (int[,])other.Grid.Clone();
        }


        public Sudoku(int[,] grid)
        {
            Grid = (int[,])grid.Clone();
        }

        public int this[int xKey, int yKey]
        {
            get => Grid[xKey, yKey];
            set => Grid[xKey, yKey] = value;
        }

        public bool isSolved()
        {
            for (int i = 0; i < Globals.SUDOKU_SIZE; i++)
            {
                for (int j = 0; j < Globals.SUDOKU_SIZE; j++)
                {
                    if (Grid[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}