using SudokuSolver.Models.Interfaces;
using System.Collections.Generic;

namespace SudokuSolver.Models
{
    public class SudokuBook : ICacheSingle<(int Id, double Difficulty, Sudoku Sudoku)>
    {
        public List<(int Id, double Difficulty, Sudoku Sudoku)> SudokuList {set; get; }
        public int Count {set; get;}
        public SudokuBook()
        {
            SudokuList = new List<(int Id, double Difficulty, Sudoku Sudoku)>();
            Count = 0;  
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

        public void Add((int Id, double Difficulty, Sudoku Sudoku) sudoku)
        {
            SudokuList.Add(sudoku);
            Count++;
        }
    }
}