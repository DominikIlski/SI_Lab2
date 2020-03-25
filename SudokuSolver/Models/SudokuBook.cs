using SudokuSolver.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver.Models
{
    public class SudokuBook : ICacheSingle<(int Id, double Difficulty, Sudoku Sudoku)>
    {

        List<(int Id, double Difficulty, Sudoku Sudoku)> SudokuList { set; get; }


        public SudokuBook()
        {

            SudokuList = new List<(int Id, double Difficulty, Sudoku Sudoku)>();

        }




        public (int Id, double Difficulty, Sudoku Sudoku) this[int key]
        { 
            get => SudokuList[key]; 
            set 
            {
                SudokuList.RemoveAt(key);
                SudokuList.Insert(key, value);

            } 
        }

        public void Add((int Id, double Difficulty, Sudoku Sudoku) sudoku) => SudokuList.Add(sudoku);

        

    }
}
