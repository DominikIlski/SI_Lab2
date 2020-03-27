using SudokuSolver.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace SudokuSolver.Services
{
    class SudokuSolver
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

        HashSet<int> SolvingOrder { set; get; }


        Sudoku? CurrentExample { set; get; }

        public SudokuSolver(SudokuBook sudokuBook)
        {

            SudokuBook = sudokuBook;
            SolvingOrder = new HashSet<int>();

        }



        public SudokuBook Solve(SudokuBook sudokuBook)
        {

            if (SudokuBook is null)
            {
                MessageBox.Show("Set sudok book befor you start solving");

                throw new Exception("No sudoku book set");

            }






            return


        }




        private void AssumeSolvingOrder()
        {




        }
        


    }
}
