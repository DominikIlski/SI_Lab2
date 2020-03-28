using SudokuSolver.Models;
using System;
using System.Collections.Generic;

namespace SudokuSolver.Services
{
    internal class SudokuSolver
    {
        public SudokuBook? SudokuBook { set; private get; }

        public SudokuBook? SolvedBook
        {
            set
            {
                SolvedBook = value;
            }

            get
            {
                return SolvedBook ?? throw new Exception("Solve sudoku book befor printing solution");
            }
        }

        private HashSet<int> SolvingOrder { set; get; }

        private Sudoku? CurrentExample { set; get; }

        public SudokuSolver(SudokuBook sudokuBook)
        {
            SudokuBook = sudokuBook;
            SolvingOrder = new HashSet<int>();
        }

        /*public SudokuBook Solve(SudokuBook sudokuBook)
        {
            if (SudokuBook is null)
            {
                MessageBox.Show("Set sudok book befor you start solving");

                throw new Exception("No sudoku book set");
            }

            return
        }*/

        private void AssumeSolvingOrder()
        {
        }
    }
}