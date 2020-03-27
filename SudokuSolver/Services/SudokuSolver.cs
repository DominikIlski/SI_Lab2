using SudokuSolver.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace SudokuSolver.Services
{
    class SudokuSolver
    {
    
        SudokuBook? SudokuBook { set; get; }
        SudokuBook? SolvedBook 
        {
            set
            {
                SolvedBook = value;
            }

            get
            {
                MessageBox.Show("Solve sudoku book befor printing solution");
                return SolvedBook;
            }
        }

        //List<> SolutionOrder


        Sudoku? CurrentExample { set; get; }

        public SudokuSolver(SudokuBook sudokuBook)
        {

            SudokuBook = sudokuBook;

        }



        public SudokuBook Solve(SudokuBook sudokuBook)
        {

            if (SudokuBook is null)
            {
                MessageBox.Show("Set sudok book befor you start solving");

                throw new Exception("No sudoku book set");

            }









        }




        



    }
}
