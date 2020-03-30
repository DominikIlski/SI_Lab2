using SudokuSolver.Models;using System;using System.Collections.Generic;using SudokuSolver.Models.VariableHeuristics;using SudokuSolver.Models.ValueHeuristics;using System.Windows;using SudokuSolver.Global;using System.Diagnostics;using System.Linq;

namespace SudokuSolver.Services{	internal class SudokuSolverAlgorithm	{		public SudokuBook? SudokuBook { set; private get; }		public VariableHeuristics VariableHeuristics { set; get; }		public ValueHeuristics ValueHeuristics { set; get; }		public List<Sudoku> AllSolutions { set; get; }		public string FirstSolutionTime { set; get; }		public string AllSolutionsTime { set; get; }		public int FirstReturnCount = 0;		public int AllReturnCount = 0;		public int AllNodes = 0;		public int FirstNodes = 0;				private List<VariableConstraint> SolvingOrder { set; get; }		private Sudoku CurrentExample { set; get; }		public SudokuSolverAlgorithm(SudokuBook sudokuBook, VariableHeuristics variableHeursitics,			ValueHeuristics valueHeuristics)		{			AllSolutions = new List<Sudoku>();			SudokuBook = sudokuBook;			SolvingOrder = new List<VariableConstraint>();			VariableHeuristics = variableHeursitics;			ValueHeuristics = valueHeuristics;		}		public List<Sudoku> Run(int sudokuId)		{			if (SudokuBook is null)			{				MessageBox.Show("Set sudok book befor you start solving");				throw new Exception("No sudoku book set");			}


			CurrentExample = SudokuBook[sudokuId].Sudoku;
			Solve();


			return AllSolutions;		}		private void Solve()		{			var stopwatch = new Stopwatch();			stopwatch.Start();
			AssumeSolvingOrder();			Node root = new Node(CurrentExample);			for (int i = 0; i < SolvingOrder[0].Domain.Count; i++)
			{

				var domain = SolvingOrder[0].Domain.ToList();
				AllReturnCount = AllReturnCount + 9 - SolvingOrder[0].Domain.Count;
				Sudoku newSudoku = new Sudoku(CurrentExample);
				newSudoku[SolvingOrder[0].X, SolvingOrder[0].Y] = domain[i];
				Node newNode = new Node(newSudoku, root);
				root.AddChild(newNode);
				AllNodes += 13;


			}			root.HasAllChildren = true;			Node current = root;						while (true)
			{

				//dodawanie dzieci
				if (!current.HasAllChildren)
				{
					CurrentExample = current.CurrentSudokuState;
					AssumeSolvingOrder();
					if (SolvingOrder.Count != 0)
					{
						for (int i = 0; i < SolvingOrder[0].Domain.Count; i++)
						{
							var domain = SolvingOrder[0].Domain.ToList();
							AllReturnCount = AllReturnCount + 9 - SolvingOrder[0].Domain.Count;
							Sudoku newSudoku = new Sudoku(CurrentExample);
							newSudoku[SolvingOrder[0].X, SolvingOrder[0].Y] = domain[i];
							Node newNode = new Node(newSudoku, current);
							current.AddChild(newNode);
							AllNodes += 13;
							

						}
						current.HasAllChildren = true;
					}

				}

				if (current.CurrentSudokuState.isSolved())
				{
					if (AllSolutions.Count == 0)
					{
						AllNodes+=9;
						AllNodes++;
						var ts = stopwatch.Elapsed;

						string elapsedTime = String.Format("{0:00}.{1:00}",
						 ts.Seconds,
						ts.Milliseconds / 10);

						FirstSolutionTime = elapsedTime;
						FirstReturnCount = AllNodes/2;
						FirstNodes = AllNodes;
					}
					/*
					 bool shouldBeAdded = true;
                    for (int i = 0; i < Solutions.Count; i++)
                    {
                        if (checkIfIsTheSameSolution(Solutions[i], current.Current))
                        {
                            shouldBeAdded = false;
                        }
                    }
                    if (shouldBeAdded)
                    {
                        Solutions.Add(current.Current);
                        Console.WriteLine();
                        current.Current.displaySudoku();
                        Console.WriteLine();
                        counter++;
                    }
					  
					 */

					AllSolutions.Add(current.CurrentSudokuState);

					AllNodes++;
					AllNodes++;
					current = current.Parent;
					current.Children.RemoveAt(0);

				}
				else if (current.HasAllChildren)
				{
					// Console.WriteLine(current.Children.Count);
					//jesli nie ma dziecka
					if (current.Children.Count == 0)
					{
						current = current.Parent;
						AllNodes++;

						//  Console.WriteLine("nawracam");
						current.Children.RemoveAt(0);
						AllNodes++;


					}
					//a jesli ma to biore pierwsze z brzegu
					else
					{
						AllNodes++;
						current = current.Children[0];
						
					}
					if (current.Equals(root) && current.Children.Count == 0 && AllSolutions.Count != 0)
					{
						stopwatch.Stop();
						AllNodes++;

						var ts = stopwatch.Elapsed;

						string elapsedTime = String.Format("{0:00}.{1:00}",
						 ts.Seconds,
						ts.Milliseconds / 10);
						AllSolutionsTime = elapsedTime;
						 
						break;
					}
				}
			}		}		private void AssumeSolvingOrder()		{
			SolvingOrder = VariableHeuristics.Assume(CurrentExample);		}



	}
}