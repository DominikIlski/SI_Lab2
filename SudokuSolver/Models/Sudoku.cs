using SudokuSolver.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver.Models
{
    public class Sudoku : ICacheMultiple<int>
    {

        int[,] Grid { set; get; }
        TimeSpan? SolveingTime { set; get; }
        int? SolutionNumber { set; get; }
        int? NodeVisited { set; get; }


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
