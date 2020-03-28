using SudokuSolver.Models;
using System;
using System.Collections.Generic;
using SudokuSolver.Models.VariableHeuristics;
using SudokuSolver.Models.ValueHeuristics;
using System.Windows;
using SudokuSolver.Global;

namespace SudokuSolver.Services
{
    internal class SudokuSolverAlgorithm
    {
        public SudokuBook? SudokuBook { set; private get; }
        public VariableHeuristics VariableHeuristics { set; get; }
        public ValueHeuristics ValueHeuristics { set; get; }
        //public List<Sudoku> AllSolutions { set; get; }
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

        private List<VariableConstraint> SolvingOrder { set; get; }

        private Sudoku CurrentExample { set; get; }

        public SudokuSolverAlgorithm(SudokuBook sudokuBook, VariableHeuristics variableHeursitics,
            ValueHeuristics valueHeuristics)
        {
            SudokuBook = sudokuBook;
            SolvingOrder = new List<VariableConstraint>();
            VariableHeuristics = variableHeursitics;
            ValueHeuristics = valueHeuristics;
        }

        public Sudoku Run()
        {
            if (SudokuBook is null)
            {
                MessageBox.Show("Set sudok book befor you start solving");

                throw new Exception("No sudoku book set");
            }

            for (int i = 0; i < SudokuBook.Count; i++)
            {
                CurrentExample = SudokuBook[i].Sudoku;
                AssumeSolvingOrder();
                Solve();
                //TODO: usunąć przy całości to tylko dla testów
                break;
            }








            return CurrentExample;
        }


        private void Solve()
        {
            for (int i = 0; i < Globals.SUDOKU_SIZE * Globals.SUDOKU_SIZE; i++)
            {
                var x = SolvingOrder[i].X;
                var y = SolvingOrder[i].Y;
                //var Domain = SolvingOrder[i].Domain;

                if (CurrentExample[x,y] == 0)
                        for (int n = 0; n < 10; n++)
                        {
                            if (possible(x, y, n))
                            {
                                CurrentExample[x, y] = n;
                                Solve();
                                CurrentExample[x, y] = 0;
                            }
                        }

                
            }
        }


        private void AssumeSolvingOrder()
        { 
            SolvingOrder = VariableHeuristics.Assume(CurrentExample);
        }


        private bool possible(int x, int y, int n)
        {
            for (int i = 0; i < 9; i++)
            {
                if (CurrentExample[x, i] == n)
                    return false;
                if (CurrentExample[i, y] == n)
                    return false;

                
            }

            return CheckSubGrid(x, y, n);
 
        }


        private bool CheckSubGrid(int row, int column, int n)
        {

            var sqrt = (int)Math.Sqrt(Globals.SUDOKU_SIZE);
            var boxRowStart = row - row % sqrt;
            var boxColStart = column - column % sqrt;

            for (int r = boxRowStart; r < boxRowStart + sqrt; r++)
                for (int c = boxColStart; c < boxRowStart + sqrt; c++)
                    if (CurrentExample[r, c] == n) return false;

            return true;


        }


    }
}